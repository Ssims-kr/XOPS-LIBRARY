# XOPS-LIBRARY

## Config.cs
"config.dat" 파일의 데이터를 읽고 쓸 수 있는 라이브러리입니다.

---

### 바로 가기
* [사용 방법](#사용-방법)
* [상수](#상수)
* [열거형](#열거형)
* [프로퍼티](#프로퍼티)
* [메서드](#메서드)
---

### 사용 방법
```csproj
<ItemGroup>
<Reference Include="Configuration.dll">
  <HintPath>Configuration.dll</HintPath>
  <SpecificVersion>false</SpecificVersion>
</Reference>
</ItemGroup>
```
VSCode를 사용하시는 경우 `.csproj` 파일을 오픈하신 후, `</PropertyGroup>` 태그 아래에 위 코드를 추가합니다.

Visual Studio IDE를 사용하시는 경우, 솔루션 탐색기에서 DLL 파일을 참조 추가해주세요.
<br>
<br>
```csharp
using XOPS;           // dll 참조 추가 후, XOPS 네임스페이스를 포함한다.
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==== 불러오기 ====
            // [1] config.dat 파일의 경로를 생성자에 넘긴다.
            var config = new Configuration("./config.dat");
            
            // [2] config.dat 파일의 경로를 LoadConfig 메서드에 넘긴다. ★
            Configuration config2;
            if (config2.LoadConfig("./config.dat") == false) {
              // 오픈 실패 시, 처리할 코드
            }
            
            
            // ==== 데이터 접근 ====
            Console.WriteLine(config.PlayerName);
            
            
            
            // ==== 저장 ====
            if (config.SaveConfig("저장할 경로") == false) {
              // 저장 실패 시, 처리할 코드
            }
        }
    }
}
```
---

### 상수
<table>
  <tbody>
    <tr>
      <td><b>상수명</b></td>
      <td><b>값</b></td>
      <td><b>형식</b></td>
      <td><b>설명</b></td>
    </tr>
    <tr>
      <td><code>TOTAL_GAME_CONTROL_KEY</code></td>
      <td>18</td>
      <td><code>Int16</code></td>
      <td>게임에서 사용되는 조작 키의 수</td>
    </tr>
    <tr>
      <td><code>MAX_PLAYER_NAME</code></td>
      <td>21</td>
      <td><code>Int16</code></td>
      <td>플레이어 이름의 최대 문자 수(NULL 포함)</td>
    </tr>
    <tr>
      <td><code>DEFAULT_PLAYER_NAME</code></td>
      <td>xopsplayer</td>
      <td><code>String</code></td>
      <td>플레이어 이름의 기본값</td>
    </tr>
  </tbody>
</table>

---

### 열거형
<table>
  <thead>
    <tr>
      <th colspan="4">GameControlKeys</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><b>상수명</b></td>
      <td><b>값</b></td>
      <td><b>형식</b></td>
      <td><b>설명</b></td>
    </tr>
    <tr>
      <td><code>TURN_UP</code></td>
      <td>0</td>
      <td><code>UInt32</code></td>
      <td>위로 보기</td>
    </tr>
    <tr>
      <td><code>TURN_DOWN</code></td>
      <td>1</td>
      <td><code>UInt32</code></td>
      <td>아래로 보기</td>
    </tr>
    <tr>
      <td><code>TURN_LEFT</code></td>
      <td>2</td>
      <td><code>UInt32</code></td>
      <td>좌로 보기</td>
    </tr>
    <tr>
      <td><code>TURN_RIGHT</code></td>
      <td>3</td>
      <td><code>UInt32</code></td>
      <td>우로 보기</td>
    </tr>
    <tr>
      <td><code>MOVE_FORWARD</code></td>
      <td>4</td>
      <td><code>UInt32</code></td>
      <td>앞으로 가기</td>
    </tr>
    <tr>
      <td><code>MOVE_BACKWARD</code></td>
      <td>5</td>
      <td><code>UInt32</code></td>
      <td>뒤로 가기</td>
    </tr>
    <tr>
      <td><code>MOVE_LEFT</code></td>
      <td>6</td>
      <td><code>UInt32</code></td>
      <td>좌로 가기</td>
    </tr>
    <tr>
      <td><code>MOVE_RIGHT</code></td>
      <td>7</td>
      <td><code>UInt32</code></td>
      <td>우로 가기</td>
    </tr>
    <tr>
      <td><code>WALK</code></td>
      <td>8</td>
      <td><code>UInt32</code></td>
      <td>걷기</td>
    </tr>
    <tr>
      <td><code>JUMP</code></td>
      <td>9</td>
      <td><code>UInt32</code></td>
      <td>점프</td>
    </tr>
    <tr>
      <td><code>RELOAD</code></td>
      <td>10</td>
      <td><code>UInt32</code></td>
      <td>재장전</td>
    </tr>
    <tr>
      <td><code>DROP_WEAPON</code></td>
      <td>11</td>
      <td><code>UInt32</code></td>
      <td>무기 버리기</td>
    </tr>
    <tr>
      <td><code>ZOOM</code></td>
      <td>12</td>
      <td><code>UInt32</code></td>
      <td>줌(확대/축소)</td>
    </tr>
    <tr>
      <td><code>SHOT_MODE</code></td>
      <td>13</td>
      <td><code>UInt32</code></td>
      <td>발사 모드</td>
    </tr>
    <tr>
      <td><code>SWITCH_WEAPON</code></td>
      <td>14</td>
      <td><code>UInt32</code></td>
      <td>무기 전환</td>
    </tr>
    <tr>
      <td><code>WEAPON_1</code></td>
      <td>15</td>
      <td><code>UInt32</code></td>
      <td>1번 무기</td>
    </tr>
    <tr>
      <td><code>WEAPON_2</code></td>
      <td>16</td>
      <td><code>UInt32</code></td>
      <td>2번 무기</td>
    </tr>
    <tr>
      <td><code>SHOT</code></td>
      <td>17</td>
      <td><code>UInt32</code></td>
      <td>발사(발포)</td>
    </tr>
  </tbody>
</table>

`GameControlKeys`는 게임에서 사용되고 있는 키의 열거형입니다. 새롭게 추가된 키가 있다면 열거형에도 추가해야 합니다.
<br>
<br>
<table>
  <thead>
    <tr>
      <th colspan="4">GameControlKeyCodes</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><b>상수명</b></td>
      <td><b>값</b></td>
      <td><b>형식</b></td>
      <td><b>설명</b></td>
    </tr>
    <tr>
      <td><code>UP</code></td>
      <td>0</td>
      <td><code>UInt32</code></td>
      <td>윗 방향키</td>
    </tr>
    <tr>
      <td><code>DOWN</code></td>
      <td>1</td>
      <td><code>UInt32</code></td>
      <td>아랫 방향키</td>
    </tr>
    <tr>
      <td><code>LEFT</code></td>
      <td>2</td>
      <td><code>UInt32</code></td>
      <td>좌측 방향키</td>
    </tr>
    <tr>
      <td><code>RIGHT</code></td>
      <td>3</td>
      <td><code>UInt32</code></td>
      <td>우측 방향키</td>
    </tr>
    <tr>
      <td><code>NUMPAD_0</code></td>
      <td>4</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 0</td>
    </tr>
    <tr>
      <td><code>NUMPAD_1</code></td>
      <td>5</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 1</td>
    </tr>
    <tr>
      <td><code>NUMPAD_2</code></td>
      <td>6</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 2</td>
    </tr>
    <tr>
      <td><code>NUMPAD_3</code></td>
      <td>7</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 3</td>
    </tr>
    <tr>
      <td><code>NUMPAD_4</code></td>
      <td>8</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 4</td>
    </tr>
    <tr>
      <td><code>NUMPAD_5</code></td>
      <td>9</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 5</td>
    </tr>
    <tr>
      <td><code>NUMPAD_6</code></td>
      <td>10</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 6</td>
    </tr>
    <tr>
      <td><code>NUMPAD_7</code></td>
      <td>11</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 7</td>
    </tr>
    <tr>
      <td><code>NUMPAD_8</code></td>
      <td>12</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 8</td>
    </tr>
    <tr>
      <td><code>NUMPAD_9</code></td>
      <td>13</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 9</td>
    </tr>
    <tr>
      <td><code>BACKSPACE</code></td>
      <td>14</td>
      <td><code>UInt32</code></td>
      <td>백스페이스</td>
    </tr>
    <tr>
      <td><code>ENTER</code></td>
      <td>15</td>
      <td><code>UInt32</code></td>
      <td>엔터(Return)</td>
    </tr>
    <tr>
      <td><code>TAB</code></td>
      <td>16</td>
      <td><code>UInt32</code></td>
      <td>탭</td>
    </tr>
    <tr>
      <td><code>SPACE</code></td>
      <td>17</td>
      <td><code>UInt32</code></td>
      <td>스페이스 바</td>
    </tr>
    <tr>
      <td><code>MOUSE_L</code></td>
      <td>18</td>
      <td><code>UInt32</code></td>
      <td>좌측 마우스 버튼</td>
    </tr>
    <tr>
      <td><code>MOUSE_R</code></td>
      <td>19</td>
      <td><code>UInt32</code></td>
      <td>우측 마우스 버튼</td>
    </tr>
    <tr>
      <td><code>SHIFT</code></td>
      <td>20</td>
      <td><code>UInt32</code></td>
      <td>시프트 키</td>
    </tr>
    <tr>
      <td><code>CTRL</code></td>
      <td>21</td>
      <td><code>UInt32</code></td>
      <td>컨트롤 키</td>
    </tr>
    <tr>
      <td><code>D0</code></td>
      <td>22</td>
      <td><code>UInt32</code></td>
      <td>0번 키</td>
    </tr>
    <tr>
      <td><code>D1</code></td>
      <td>23</td>
      <td><code>UInt32</code></td>
      <td>1번 키</td>
    </tr>
    <tr>
      <td><code>D2</code></td>
      <td>24</td>
      <td><code>UInt32</code></td>
      <td>2번 키</td>
    </tr>
    <tr>
      <td><code>D3</code></td>
      <td>25</td>
      <td><code>UInt32</code></td>
      <td>3번 키</td>
    </tr>
    <tr>
      <td><code>D4</code></td>
      <td>26</td>
      <td><code>UInt32</code></td>
      <td>4번 키</td>
    </tr>
    <tr>
      <td><code>D5</code></td>
      <td>27</td>
      <td><code>UInt32</code></td>
      <td>5번 키</td>
    </tr>
    <tr>
      <td><code>D6</code></td>
      <td>28</td>
      <td><code>UInt32</code></td>
      <td>6번 키</td>
    </tr>
    <tr>
      <td><code>D7</code></td>
      <td>29</td>
      <td><code>UInt32</code></td>
      <td>7번 키</td>
    </tr>
    <tr>
      <td><code>D8</code></td>
      <td>30</td>
      <td><code>UInt32</code></td>
      <td>8번 키</td>
    </tr>
    <tr>
      <td><code>D9</code></td>
      <td>31</td>
      <td><code>UInt32</code></td>
      <td>9번 키</td>
    </tr>
    <tr>
      <td><code>A</code></td>
      <td>32</td>
      <td><code>UInt32</code></td>
      <td>A</td>
    </tr>
    <tr>
      <td><code>B</code></td>
      <td>33</td>
      <td><code>UInt32</code></td>
      <td>B</td>
    </tr>
    <tr>
      <td><code>C</code></td>
      <td>34</td>
      <td><code>UInt32</code></td>
      <td>C</td>
    </tr>
    <tr>
      <td><code>D</code></td>
      <td>35</td>
      <td><code>UInt32</code></td>
      <td>D</td>
    </tr>
    <tr>
      <td><code>E</code></td>
      <td>36</td>
      <td><code>UInt32</code></td>
      <td>E</td>
    </tr>
    <tr>
      <td><code>F</code></td>
      <td>37</td>
      <td><code>UInt32</code></td>
      <td>F</td>
    </tr>
    <tr>
      <td><code>G</code></td>
      <td>38</td>
      <td><code>UInt32</code></td>
      <td>G</td>
    </tr>
    <tr>
      <td><code>H</code></td>
      <td>39</td>
      <td><code>UInt32</code></td>
      <td>H</td>
    </tr>
    <tr>
      <td><code>I</code></td>
      <td>40</td>
      <td><code>UInt32</code></td>
      <td>I</td>
    </tr>
    <tr>
      <td><code>J</code></td>
      <td>41</td>
      <td><code>UInt32</code></td>
      <td>J</td>
    </tr>
    <tr>
      <td><code>K</code></td>
      <td>42</td>
      <td><code>UInt32</code></td>
      <td>K</td>
    </tr>
    <tr>
      <td><code>L</code></td>
      <td>43</td>
      <td><code>UInt32</code></td>
      <td>L</td>
    </tr>
    <tr>
      <td><code>M</code></td>
      <td>44</td>
      <td><code>UInt32</code></td>
      <td>M</td>
    </tr>
    <tr>
      <td><code>N</code></td>
      <td>45</td>
      <td><code>UInt32</code></td>
      <td>N</td>
    </tr>
    <tr>
      <td><code>O</code></td>
      <td>46</td>
      <td><code>UInt32</code></td>
      <td>O</td>
    </tr>
    <tr>
      <td><code>P</code></td>
      <td>47</td>
      <td><code>UInt32</code></td>
      <td>P</td>
    </tr>
    <tr>
      <td><code>Q</code></td>
      <td>48</td>
      <td><code>UInt32</code></td>
      <td>Q</td>
    </tr>
    <tr>
      <td><code>R</code></td>
      <td>49</td>
      <td><code>UInt32</code></td>
      <td>R</td>
    </tr>
    <tr>
      <td><code>S</code></td>
      <td>50</td>
      <td><code>UInt32</code></td>
      <td>S</td>
    </tr>
    <tr>
      <td><code>T</code></td>
      <td>51</td>
      <td><code>UInt32</code></td>
      <td>T</td>
    </tr>
    <tr>
      <td><code>U</code></td>
      <td>52</td>
      <td><code>UInt32</code></td>
      <td>U</td>
    </tr>
    <tr>
      <td><code>V</code></td>
      <td>53</td>
      <td><code>UInt32</code></td>
      <td>V</td>
    </tr>
    <tr>
      <td><code>W</code></td>
      <td>54</td>
      <td><code>UInt32</code></td>
      <td>W</td>
    </tr>
    <tr>
      <td><code>X</code></td>
      <td>55</td>
      <td><code>UInt32</code></td>
      <td>X</td>
    </tr>
    <tr>
      <td><code>Y</code></td>
      <td>56</td>
      <td><code>UInt32</code></td>
      <td>Y</td>
    </tr>
    <tr>
      <td><code>Z</code></td>
      <td>57</td>
      <td><code>UInt32</code></td>
      <td>Z</td>
    </tr>
    <tr>
      <td><code>SLASH</code></td>
      <td>58</td>
      <td><code>UInt32</code></td>
      <td>/</td>
    </tr>
    <tr>
      <td><code>COLON</code></td>
      <td>59</td>
      <td><code>UInt32</code></td>
      <td>:</td>
    </tr>
    <tr>
      <td><code>SEMICLON</code></td>
      <td>60</td>
      <td><code>UInt32</code></td>
      <td>;</td>
    </tr>
    <tr>
      <td><code>HYPHEN</code></td>
      <td>61</td>
      <td><code>UInt32</code></td>
      <td>-</td>
    </tr>
    <tr>
      <td><code>AT</code></td>
      <td>62</td>
      <td><code>UInt32</code></td>
      <td>@</td>
    </tr>
    <tr>
      <td><code>L_BRACKET</code></td>
      <td>63</td>
      <td><code>UInt32</code></td>
      <td>[</td>
    </tr>
    <tr>
      <td><code>R_BRACKET</code></td>
      <td>64</td>
      <td><code>UInt32</code></td>
      <td>]</td>
    </tr>
    <tr>
      <td><code>YEN</code></td>
      <td>65</td>
      <td><code>UInt32</code></td>
      <td>YEN(일본 자판기의 역슬래시??)</td>
    </tr>
    <tr>
      <td><code>BACKSLASH</code></td>
      <td>66</td>
      <td><code>UInt32</code></td>
      <td>\</td>
    </tr>
    <tr>
      <td><code>COMMA</code></td>
      <td>67</td>
      <td><code>UInt32</code></td>
      <td>,</td>
    </tr>
    <tr>
      <td><code>PERIOD</code></td>
      <td>68</td>
      <td><code>UInt32</code></td>
      <td>.</td>
    </tr>
    <tr>
      <td><code>CARET</code></td>
      <td>69</td>
      <td><code>UInt32</code></td>
      <td>^</td>
    </tr>
    <tr>
      <td><code>NUMPAD_MULTIPLY</code></td>
      <td>70</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 *</td>
    </tr>
    <tr>
      <td><code>NUMPAD_DIVISION</code></td>
      <td>71</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 /</td>
    </tr>
    <tr>
      <td><code>NUMPAD_ADDTIVE</code></td>
      <td>72</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 +</td>
    </tr>
    <tr>
      <td><code>NUMPAD_SUBTRACK</code></td>
      <td>73</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 -</td>
    </tr>
    <tr>
      <td><code>NUMPAD_PERIOD</code></td>
      <td>74</td>
      <td><code>UInt32</code></td>
      <td>넘버패드 .</td>
    </tr>
  </tbody>
</table>

`GameControlKeyCodes`는 게임에서 사용되는 조작 키의 코드 열거형입니다. 조작 키에 해당하는 코드이며, 새롭게 추가되는 키 코드가 있다면 열거형에도 추가해야 합니다.
<br>

---

### 프로퍼티
<table>
  <tbody>
    <tr>
      <td><b>프로퍼티명</b></td>
      <td><b>값</b></td>
      <td><b>형식</b></td>
      <td><b>설명</b></td>
    </tr>
    <tr>
      <td>GameControlKeyCode</td>
      <td><code>GameControlKeyCodes</code></td>
      <td><code>GameControlKeyCodes[]</code></td>
      <td>게임 조작 키 코드를 가지는 배열 프로퍼티.</td>
    </tr>
    <tr>
      <td>MouseSensitivity</td>
      <td><code>0 ~ 255</code></td>
      <td><code>Byte</code></td>
      <td>마우스 감도</td>
    </tr>
    <tr>
      <td>FullScreenFlag</td>
      <td><code>true</code>, <code>false</code></td>
      <td><code>Boolean</code></td>
      <td>전체화면 플래그<br><br><code>true</code> : 전체화면, <code>false</code> : 창 모드</td>
    </tr>
    <tr>
      <td>SoundFlag</td>
      <td><code>true</code>, <code>false</code></td>
      <td><code>Boolean</code></td>
      <td>사운드 플래그<br><br><code>true</code> : 활성화, <code>false</code> : 비활성화</td>
    </tr>
    <tr>
      <td>BloodFlag</td>
      <td><code>true</code>, <code>false</code></td>
      <td><code>Boolean</code></td>
      <td>혈흔 플래그<br><br><code>true</code> : 활성화, <code>false</code> : 비활성화</td>
    </tr>
    <tr>
      <td>ScreenBrightness</td>
      <td><code>0 ~ 255</code></td>
      <td><code>Byte</code></td>
      <td>화면 밝기</td>
    </tr>
    <tr>
      <td>InvertMouseFlag</td>
      <td><code>true</code>, <code>false</code></td>
      <td><code>Boolean</code></td>
      <td>마우스 반전 플래그<br><br><code>true</code> : 활성화, <code>false</code> : 비활성화</td>
    </tr>
    <tr>
      <td>FrameSkipFlag</td>
      <td><code>true</code>, <code>false</code></td>
      <td><code>Boolean</code></td>
      <td>프레임 스킵 플래그<br><br><code>true</code> : 활성화, <code>false</code> : 비활성화</td>
    </tr>
    <tr>
      <td>AnotherGunsightFlag</td>
      <td><code>true</code>, <code>false</code></td>
      <td><code>Boolean</code></td>
      <td>다른 건사이트 플래그<br><br><code>true</code> : 활성화, <code>false</code> : 비활성화</td>
    </tr>
    <tr>
      <td>PlayerName</td>
      <td><code>String</code></td>
      <td><code>String</code></td>
      <td>플레이어 이름(문자열)</td>
    </tr>
    
  </tbody>
</table>

각 프로퍼티는 `get`과 `set`이 가능합니다.

---

### 메서드
<table>
  <tbody>
    <tr>
      <td><b>메서드명</b></td>
      <td><b>반환 형식</b></td>
      <td><b>매개변수</b></td>
      <td><b>설명</b></td>
    </tr>
    <tr>
      <td><code>LoadConfig</code></td>
      <td><code>Boolean</code><br><br><code>true</code> : 성공, <code>false</code> : 실패</td>
      <td><code>String file_path</code><br><br><code>file_path</code> : 게임 설정 파일의 경로</td>
      <td>게임 설정 파일의 데이터를 읽어옵니다.</td>
    </tr>
    <tr>
      <td><code>SaveConfig</code></td>
      <td><code>Boolean</code><br><br><code>true</code> : 성공, <code>false</code> : 실패</td>
      <td><code>String file_path</code><br><br><code>file_path</code> : 게임 설정 파일의 경로</td>
      <td>게임 설정 파일의 데이터를 저장합니다.</td>
    </tr>
    <tr>
      <td><code>CreateConfig</code></td>
      <td><code>Boolean</code><br><br><code>true</code> : 성공, <code>false</code> : 실패</td>
      <td><code>String file_path</code><br><br><code>file_path</code> : 게임 설정 파일의 경로</td>
      <td>게임 설정 파일의 데이터를 생성합니다.<br><br>이미 게임 설정 파일이 존재하는 경우 <code>false</code>가 반환됩니다.</td>
    </tr>
    <tr>
      <td><code>ResetConfigValue</code></td>
      <td><code>void</code></td>
      <td></td>
      <td>게임 설정 값을 기본 값으로 초기화합니다.</td>
    </tr>
  </tbody>
</table>
