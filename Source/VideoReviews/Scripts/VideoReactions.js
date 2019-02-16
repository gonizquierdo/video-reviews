// apply some workarounds for opera browser
applyVideoWorkaround();

function viewReview() {
    var videoId = $(this).data("videoid");
    var reviewVideoUrl = $(this).data("reviewsrc");
    var reviewVideo = $('<video id="reviewVideo controls="controls" class="reviewVideo"></video>');
    reviewVideo.append('<source src="' + reviewVideoUrl + '" type="video/webm" />');
    var video = $("#video_" + videoId);
    video.siblings("video").remove();
    reviewVideo.insertAfter(video);
    reviewVideo[0].currentTime = 0;
    video[0].currentTime = 0;
    video[0].play();
    reviewVideo[0].play();
        
}

function captureReaction() {
    var videoId = $(this).data("videoid");
    var video = $("#video_" + videoId)[0];
    var options = {
        controls: true,
        width: 320,
        height: 240,
        fluid: false,
        plugins: {
            record: {
                audio: true,
                video: true,
                maxLength: video.duration,
                debug: true
            }
        }
    };
    
    var videoPlayer = $('<video id="myVideo" class="video-js vjs-default-skin"></video>');
    $(videoPlayer).insertAfter($(this));
    var player = videojs('myVideo', options, function () {
        // print version information at startup
        var msg = 'Using video.js ' + videojs.VERSION +
            ' with videojs-record ' + videojs.getPluginVersion('record') +
            ' and recordrtc ' + RecordRTC.version;
        videojs.log(msg);
    });
    // error handling
    player.on('deviceError', function () {
        console.log('device error:', player.deviceErrorCode);
    });
    player.on('error', function (element, error) {
        console.error(error);
    });
    // user clicked the record button and started recording
    player.on('startRecord', function () {
        console.log('started recording!');
        
        video.currentTime = 0;
        video.play();
    });
    // user completed recording and stream is available
    player.on('finishRecord', function () {
        // the blob object contains the recorded data that
        // can be downloaded by the user, stored on server etc.
        console.log('finished recording: ', player.recordedData);
        var data = player.recordedData;
        var serverUrl = '/VideoRecording/UploadReview';
        var formData = new FormData();
        formData.append('file', data, data.name);
        formData.append('videoId', videoId);

        console.log('uploading recording:', data.name);

        fetch(serverUrl, {
            method: 'POST',
            body: formData
        }).then(
            success => {
                console.log('recording upload complete.');
                videoPlayer.remove();
            }
        ).catch(
            error => console.error('an upload error occurred!')
        );
    });
}
