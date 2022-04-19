<!DOCTYPE html>
<html>
<head>
    <style>
        body {
  justify-content: center;
  align-items: center;
  background: rgba(1,1,1,0.0);
  display: block;
  height: 100vh;
  padding: 0;
  margin: 0;
}

.progress {
  background: rgba(120,204,204,0.5);
  justify-content: flex-start;
  border-radius: 100px;
  align-items: center;
  position: relative;
  padding: 0 5px;
  display: flex;
  height: 40px;
  width: 500px;
}

.progress-value {
  animation: load 3s normal forwards;
  box-shadow: 0 10px 40px -10px #fff;
  border-radius: 100px;
  background: #7FC9FF;
  height: 30px;
  width: 0;
}

        <?php 
    $InhaltJson = file_get_contents('/home/pi/Antonbot/SkillAusgabe.json');
    //$Eintrag = new Eintraege;
    $Eintrag = json_decode($InhaltJson,true);

    $AltProzent=$Eintrag["AltProzent"];
    $NeuProzent=$Eintrag["NeuProzent"];
    //var_dump($Eintrag);

        echo "@keyframes load {
        0% { width: $AltProzent%; } 
        100% { width: $NeuProzent%; }
        }";
        ?>
.ExpText{
	text-align:center;
	width:510px;
	z-index: 1;
	position: absolute;
	font-size: 20px;
	padding-top:10px;
	font-family: Verdana, sans-serif;
	}
.text {
    color: #000000;
    font-size: 35px;
    border-style: solid;
    align-items: center;
    padding: 5px;
    z-index: 1;
    display: flex;
    height: auto;
    width: 510px;
	font-family: Verdana, sans-serif;
	}

    </style>
</head>
<body>


<div class="text"> 
    <?php 
        $InhaltJson = file_get_contents('/home/pi/Antonbot/SkillAusgabe.json');
        $Eintrag = json_decode($InhaltJson,true);

        $QuestInhalt=$Eintrag["CurrentMainQuest"]

        echo "<p>$QuestInhalt</p>"
    ?>
</div>

<div class="ExpText">
    <?php 
        $InhaltJson = file_get_contents('/home/pi/Antonbot/SkillAusgabe.json');
        $Eintrag = json_decode($InhaltJson,true);

        $EXP=$Eintrag["NeuEXP"]
        $MaxEXP=$Eintrag["NeuMaxEXP"]

        echo "<p>$EXP / $MaxEXP</p>"
    ?>    
</div>
<div class="progress">
  <div class="progress-value"></div>
</div>


</body>
</html>
