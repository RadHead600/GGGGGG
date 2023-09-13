mergeInto(LibraryManager.library, {

	SaveExtern: function(date) {
    	var dateString = UTF8ToString(date);
    	var myobj = JSON.parse(dateString);
    	player.setData(myobj);
		myGameInstance.SendMessage('GameParametersLoaderCanvas', 'TakeStack');
  	},

  	LoadExtern: function(){
    	player.getData().then(_date => {
        	const myJSON = JSON.stringify(_date);
        	myGameInstance.SendMessage('LevelManager', 'SetInformationFromJSON', myJSON);
    	});
 	},
	
    GetLang: function() {
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);
        return buffer;
    },

	InitPlayer: function() {
		if (player === undefined){
			auth();
			return false;
		}

		if ((player.getMode() === 'lite'))
		{
			return false;
		}
		return true;
	},

	ShowInternal: function() {
		ysdk.adv.showFullscreenAdv({
			callbacks: {
				onClose: function(wasShow) {
					myGameInstance.SendMessage('LevelManager', 'CloseAdvertisement');
				},
				onError: function(error) {
					console.log(error);
				}
			}
		});
	},

	ShowRewardedVideo: function() {
		ysdk.adv.showRewardedVideo({
			callbacks: {
				onOpen: () => {
					console.log('Video ad open.');
				},
				onRewarded: () => {
					myGameInstance.SendMessage('LevelManager', 'AddGems', 100);
				},
				onClose: () => {
					myGameInstance.SendMessage('LevelManager', 'CloseAdvertisement');
				}, 
				onError: (e) => {
					console.log('Error while open video ad:', e);
				}
			}
		});
	},

	SetToLeaderboard: function(value) {
		ysdk.getLeaderboards()
			.then(lb =>
			lb.SetToLeaderboardScore('LevelRecord', value));
	},

  });