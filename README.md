# RhythmJanken
インスタントゲーム部 第1弾「リズムじゃんけん」

## モック取説
・制作環境Unity.Ver2018.1.0、実機はAndroid想定  
インゲーム中、左のタイムゲージ減少率は仕様書では1秒12でしたが  
モックとして程々に遊べるように1秒6にしてあります（ゲージMAX：100）  
  
・その他、インスペクタ上でゲーム内の値をいじりたい人向け↓  
//InGameController内の変数  
    →Timer Val Max…タイムゲージ最大値  
    →Time Damage Rate…タイムゲージ秒間減少率  
    →Miss Damage Rate…指令ミス時のタイムゲージ減少率  
    →Hit Recovery Rate…指令成功時のタイムゲージ回復率  
    →Reset Order Count…指令切り替えまでの回数  


