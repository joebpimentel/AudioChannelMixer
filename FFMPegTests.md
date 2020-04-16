# FFMPEG tests with media converter and player


ffmpeg options tested until now:

# Working tests

## Test 1
the best approach until now to transmit the stream from one ffmpeg to ffplay is the following

1) at one command line, type the following command, for instance:
```cmd
ffplay -rtsp_flags listen rtsp://localhost:8888/live.sdp?tcp
```
2) at the second command line, type the following command:
```cmd
ffmpeg -i input.mp3 -f rtsp -rtsp_transport tcp rtsp://localhost:8888/live.sdp
```

The process at 1) waits until the media is played in process at 2) and then starts to play the audio.


## Test 2

1) at one command line, starts the player by listening to the desired port:
```cmd
ffplay -rtsp_flags listen rtsp://localhost:8890/live.sdp
```

2) at a second command line, starts the ffmpeg instance that would join the streams:
```cmd
ffmpeg -rtsp_flags listen -i rtsp://localhost:8889/live.sdp?tcp -f rtsp -rtsp_transport  tcp rtsp://localhost:8890/live.sdp
```

3) at a third command line, starts one ffmpeg to convert from 1st media to rtsp:
```cmd
ffmpeg -i input1.mp3 -f rtsp -rtsp_transport tcp rtsp://localhost:8889/live.sdp
```

The process at 1) waits until the media is forwarded in process at 2) that, by itself, waits for process 3) to start playing the audio.

 
# Not yet working test

To join audios from several media files, the idea is to use ffmpeg to join the streams and output to a single output in rtsp that will be
listened and played by ffplay. I've tried that but with no success.
The tentative would be as follow:

1) at one command line, starts the player by listening to the desired port:
```cmd
ffplay -rtsp_flags listen rtsp://localhost:8890/live.sdp?tcp
```

2) at a second command line, starts the ffmpeg instance that would join the streams:
```cmd
ffmpeg -i rtsp://localhost:8888/live.sdp?listen \
	   -i rtsp://localhost:8889/live.sdp?listen \
	   -f rtsp \
	   -rtsp_transport \
	   tcp \
	   rtsp://localhost:8890/live.sdp
```
	  
3) at a third command line, starts one ffmpeg to convert from 1st media to rtsp:
```cmd
ffmpeg -i input1.mp3 -f rtsp -rtsp_transport tcp rtsp://localhost:8888/live.sdp
```

4) at a fourth command line, starts one ffmpeg to convert from 2nd media to rtsp:
```cmd
ffmpeg -i input2.mp3 -f rtsp -rtsp_transport tcp rtsp://localhost:8889/live.sdp
```