<html>
<head>
    <meta http-equiv="Page-Enter" content="revealTrans(Duration=0.5,Transition=12)">
    <meta http-equiv="Page-Exit" content="revealTrans(Duration=0.5,Transition=12)">
    <title>Bowling Scoring Game</title>
    <div class="jumbotron">
        <script language=javascript>
            shot = new Array(21);
            score = new Array(11);
            function runScript() {
                store();
                valid = verify();
                if (valid) { calculate(); print(); }
            }

            function store() {
                shot[0] = document.score.shot1a.value;
                shot[1] = document.score.shot1b.value;
                shot[2] = document.score.shot2a.value;
                shot[3] = document.score.shot2b.value;
                shot[4] = document.score.shot3a.value;
                shot[5] = document.score.shot3b.value;
                shot[6] = document.score.shot4a.value;
                shot[7] = document.score.shot4b.value;
                shot[8] = document.score.shot5a.value;
                shot[9] = document.score.shot5b.value;
                shot[10] = document.score.shot6a.value;
                shot[11] = document.score.shot6b.value;
                shot[12] = document.score.shot7a.value;
                shot[13] = document.score.shot7b.value;
                shot[14] = document.score.shot8a.value;
                shot[15] = document.score.shot8b.value;
                shot[16] = document.score.shot9a.value;
                shot[17] = document.score.shot9b.value;
                shot[18] = document.score.shot10a.value;
                shot[19] = document.score.shot10b.value;
                shot[20] = document.score.shot10c.value;
            }
            function verify() {
                //for first 9 frames
                for (i = 0; i <= 17; i += 2) {
                    switch (shot[i]) {//first shot of the frame
                        case 'x': case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9': break;
                        default: alert("Invalid"); return false;
                    }

                    switch (shot[i + 1]) {//second shot of the frame
                        case '/': if (shot[i] < '0' || shot[i] > '9') { alert("Invalid"); return false; }
                        case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9': if (parseInt(shot[i]) + parseInt(shot[i + 1]) > 9) { alert("Invalid"); return false; } break;
                        default: if (shot[i] != 'x') { alert("Invalid"); return false; }
                    }
                }

                //for tenth frame
                switch (shot[18]) {//first shot
                    case 'x': case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9': break;
                    default: alert("Invalid"); return false;
                }

                switch (shot[19]) {//second shot
                    case 'x': if (shot[18] != 'x') { alert("Invalid"); return false; } break;
                    case '/': if (shot[18] < '0' || shot[18] > '9') { alert("Invalid"); return false; } break;
                    case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9':
                        if (shot[18] != 'x') { if (parseInt(shot[18]) + parseInt(shot[19]) > 9) { alert("Invalid"); return false; } } break;
                    default: alert("Invalid"); return false;
                }

                if (shot[18] != 'x' && shot[19] != '/') return true;

                switch (shot[20]) {//third shot
                    case 'x': if (shot[19] != 'x' && shot[19] != '/') { alert("Invalid"); return false; } break;
                    case '/': if (shot[19] < '0' || shot[19] > '9') { alert("Invalid"); return false; } break;
                    case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9':
                        if (shot[19] != 'x' && shot[19] != '/') { if (parseInt(shot[18]) + parseInt(shot[19]) > 9) { alert("Invalid"); return false; } } break;
                    default: alert("Invalid"); return false;
                }

                return true;
            }

            function calculate() {
                frame = 0;
                lastFrame = 0;
                for (i = 0; i < 8; i++) {//this will be the first 8 frames
                    if (shot[2 * i] == 'x') {//will strike this frame
                        if ((shot[2 * i + 2] == 'x') && (shot[2 * i + 4] == 'x')) //will strike on next 2 shots
                            score[i] = lastFrame + 30;
                        else if (shot[2 * i + 2] == 'x') //one more strike after this
                            score[i] = lastFrame + 20 + parseInt(shot[2 * i + 4]);
                        else if (shot[2 * i + 3] == '/') //the strike followed by a spare
                            score[i] = lastFrame + 20;
                        else //the strike followed by an open
                            score[i] = lastFrame + 10 + parseInt(shot[2 * i + 2]) + parseInt(shot[2 * i + 3]);
                    }

                    else if (shot[2 * i + 1] == '/') { //will spare this frame
                        if (shot[2 * i + 2] == 'x') //the next shot is a strike
                            score[i] = lastFrame + 20;
                        else //the next shot not a strike
                            score[i] = lastFrame + 10 + parseInt(shot[2 * i + 2]);
                    }

                    else //will open this frame
                        score[i] = lastFrame + parseInt(shot[2 * i]) + parseInt(shot[2 * i + 1]);
                    lastFrame = score[i];
                }
                //9th frame
                if (shot[16] == 'x') {//will strike this frame
                    if ((shot[18] == 'x') && (shot[19] == 'x'))//will followed by 2 strikes in tenth
                        score[8] = lastFrame + 30;
                    else if (shot[18] == 'x')//will followed by 1 strike in the tenth
                        score[8] = lastFrame + 20 + parseInt(shot[19]);
                    else if (shot[19] == '/')//will followed by a spare in the tenth
                        score[8] = lastFrame + 20;
                    else//will followed by an open in the tenth
                        score[8] = lastFrame + 10 + parseInt(shot[18]) + parseInt(shot[19]);
                }

                else if (shot[17] == '/') {//will spare this frame
                    if (shot[18] == 'x')//will followed by a strike in tenth
                        score[8] = lastFrame + 20;
                    else//will followed by something else
                        score[8] = lastFrame + 10 + parseInt(shot[18]);
                }

                else //will open the frame
                    score[8] = lastFrame + parseInt(shot[16]) + parseInt(shot[17]);
                lastFrame = score[8];
                //10th frame
                if (shot[18] == 'x') { //the first shot is a strike
                    if ((shot[19] == 'x') && (shot[20] == 'x'))//the 3 strikes in the tenth
                        score[9] = lastFrame + 30;
                    else if (shot[19] == 'x')//the first 2 are strikes
                        score[9] = lastFrame + 20 + parseInt(shot[20]);
                    else if (shot[20] == '/')//the one strike followed by a spare
                        score[9] = lastFrame + 20;
                    else//the one strike followed by an open
                        score[9] = lastFrame + 10 + parseInt(shot[19]) + parseInt(shot[20]);
                }

                else if (shot[19] == '/') { //the first shot is a spare
                    if (shot[20] == 'x') //spare followed by a strike
                        score[9] = lastFrame + 20;
                    else//spare followed by an open
                        score[9] = lastFrame + 10 + parseInt(shot[20]);
                }

                else //will open the tenth
                    score[9] = lastFrame + parseInt(shot[18]) + parseInt(shot[19]);
            }

            function print() {
                outputWindow = window.open('', '', 'status=0,height=250,width=500');
                output = "<title>Your Bowling Score</title>"
                output += "<h1>Your Bowling Score</h1><table border=2 width=90%>";
                output += "<tr><td>Frame:</td><td>1</td><td>2</td><td>3</td><td>4</td><td>5</td><td>6</td><td>7</td><td>8</td><td>9</td><td>10</td></tr>";
                output += "<tr><td>Score:</td><td>" + score[0] + "</td>";
                output += "<td>" + score[1] + "</td>";
                output += "<td>" + score[2] + "</td>";
                output += "<td>" + score[3] + "</td>";
                output += "<td>" + score[4] + "</td>";
                output += "<td>" + score[5] + "</td>";
                output += "<td>" + score[6] + "</td>";
                output += "<td>" + score[7] + "</td>";
                output += "<td>" + score[8] + "</td>";
                output += "<td>" + score[9] + "</td>";
                output += "</tr></table>";

                if (score[9] == 300) output += "<br><h3>Congratulations, You have Bowled a 300!!!</h3>";
                output += "<center><a onclick='outputWindow = window.close()' href=''>Close</a></center>"
                outputWindow.document.write(output);
            }
        </script>
</head>

<body bgcolor="#82ffff">
    <center><h1>Bowling Scoring Game</h1></center> <br />
    <form name="score">
        &nbsp;<center>
            <table border="1" cellspacing="1" width="100%" id="AutoNumber1" height="45">
                <tr>
                    <td width="7%" height="19" bgcolor="#green"><font color="#FFFFFF"><center><b>Frame</b><center></font></td>
                    <td width="7%" height="19" bgcolor="#green" align="center"><b>1</b></td>
                    <td width="7%" height="19" bgcolor="#green" align="center"><b>2</b></td>
                    <td width="7%" height="19" bgcolor="#green" align="center"><b>3</b></td>
                    <td width="7%" height="19" bgcolor="#green" align="center"><b>4</b></td>
                    <td width="7%" height="19" bgcolor="#green" align="center"><b>5</b></td>
                    <td width="7%" height="19" bgcolor="#green" align="center"><b>6</b></td>
                    <td width="7%" height="19" bgcolor="#green" align="center"><b>7</b></td>
                    <td width="7%" height="19" bgcolor="#green" align="center"><b>8</b></td>
                    <td width="7%" height="19" bgcolor="#green" align="center"><b>9</b></td>
                    <td width="7%" height="19" bgcolor="#green" align="center"><b>10</b></td>
                </tr>
                <tr>
                    <td width="7%" height="16" bgcolor="yellow"><font color="#FFFFFF"><b>Score</b></font></td>
                    <td width="7%" height="16" bgcolor="yellow" align="center"><input type=text maxlength=1 size=1 name="shot1a"> <input type=text maxlength=1 size=1 name="shot1b"></td>
                    <td width="7%" height="16" bgcolor="yellow" align="center"><input type=text maxlength=1 size=1 name="shot2a"> <input type=text maxlength=1 size=1 name="shot2b"></td>
                    <td width="7%" height="16" bgcolor="yellow" align="center"><input type=text maxlength=1 size=1 name="shot3a"> <input type=text maxlength=1 size=1 name="shot3b"></td>
                    <td width="7%" height="16" bgcolor="yellow" align="center"><input type=text maxlength=1 size=1 name="shot4a"> <input type=text maxlength=1 size=1 name="shot4b"></td>
                    <td width="7%" height="16" bgcolor="yellow" align="center"><input type=text maxlength=1 size=1 name="shot5a"> <input type=text maxlength=1 size=1 name="shot5b"></td>
                    <td width="7%" height="16" bgcolor="yellow" align="center"><input type=text maxlength=1 size=1 name="shot6a"> <input type=text maxlength=1 size=1 name="shot6b"></td>
                    <td width="7%" height="16" bgcolor="yellow" align="center"><input type=text maxlength=1 size=1 name="shot7a"> <input type=text maxlength=1 size=1 name="shot7b"></td>
                    <td width="7%" height="16" bgcolor="yellow" align="center"><input type=text maxlength=1 size=1 name="shot8a"> <input type=text maxlength=1 size=1 name="shot8b"></td>
                    <td width="7%" height="16" bgcolor="yellow" align="center"><input type=text maxlength=1 size=1 name="shot9a"> <input type=text maxlength=1 size=1 name="shot9b"></td>
                    <td width="7%" height="16" bgcolor="yellow" align="center"><input type=text maxlength=1 size=1 name="shot10a"> <input type=text maxlength=1 size=1 name="shot10b"> <input type=text maxlength=1 size=1 name="shot10c"></td>
                </tr>
            </table>
            <p>
                <input type=button value="Calculate Score" onclick="runScript();">
                <input type=reset value="Reset">
            </p>
        </center>
    </form>
    <h3>
        <i>
            Score: <b>0-9</b> <font color="#C0C0C0">or</font> <b>x </b>
            <font color="#C0C0C0">or</font><b> /</b>
        </i>
    </h3>
    <hr>
    </div>

</body>
</html>
