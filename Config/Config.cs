namespace XOPS {
    /// <summary>
    /// 게임 설정을 관리하는 클래스입니다.
    /// </summary>
    public class Configuration {
        #region Constants
        /// <summary>
        /// 사용되고 있는 게임 조작 키의 수
        /// </summary>
        public const Int32 TOTAL_GAME_CONTROL_KEY = 18;
        /// <summary>
        /// 플레이어 이름의 최대 문자 수(NULL 포함)
        /// </summary>
        public const Int32 MAX_PLAYER_NAME = 20 + 1;
        /// <summary>
        /// 플레이어 이름의 기본값
        /// </summary>
        public const String DEFAULT_PLAYER_NAME = "xopsplayer";
        #endregion

        #region Enums
        /// <summary>
        /// 게임 조작 키 열거형
        /// </summary>
        public enum GameControlKeys : UInt32 {
            TURN_UP,
            TURN_DOWN,
            TURN_LEFT,
            TURN_RIGHT,
            MOVE_FORWARD,
            MOVE_BACKWARD,
            MOVE_LEFT,
            MOVE_RIGHT,
            WALK,
            JUMP,
            RELOAD,
            DROP_WEAPON,
            ZOOM,
            SHOT_MODE,
            SWITCH_WEAPON,
            WEAPON_1,
            WEAPON_2,
            SHOT,
        }

        /// <summary>
        /// 게임 조작 키 코드 열거형
        /// </summary>
        public enum GameControlKeyCodes : UInt32 {
            UP,
            DOWN,
            LEFT,
            RIGHT,
            NUMPAD_0,
            NUMPAD_1,
            NUMPAD_2,
            NUMPAD_3,
            NUMPAD_4,
            NUMPAD_5,
            NUMPAD_6,
            NUMPAD_7,
            NUMPAD_8,
            NUMPAD_9,
            BACKSPACE,
            ENTER,
            TAB,
            SPACE,
            MOUSE_L,
            MOUSE_R,
            SHIFT,
            CTRL,
            D0,
            D1,
            D2,
            D3,
            D4,
            D5,
            D6,
            D7,
            D8,
            D9,
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z,
            SLASH,
            COLON,
            SEMICOLON,
            HYPHEN,
            AT,
            L_BRACKET,
            R_BRACKET,
            YEN,
            BACKSLASH,
            COMMA,
            PERIOD,
            CARET,
            NUMPAD_MULTIPLY,
            NUMPAD_DIVISION,
            NUMPAD_ADDTIVE,
            NUMPAD_SUBTRACK,
            NUMPAD_PERIOD,
        }
        #endregion

        #region Properties
        /// <summary>
        /// 게임 조작 키 코드를 설정하거나 취득할 수 있습니다.
        /// </summary>
        public GameControlKeyCodes[] GameControlKeyCode { get; set; }
        /// <summary>
        /// 마우스 감도를 설정하거나 취득할 수 있습니다.
        /// </summary>
        public Byte MouseSensitivity { get; set; }
        /// <summary>
        /// 전체화면 플래그를 설정하거나 취득할 수 있습니다.
        /// </summary>
        public Boolean FullScreenFlag { get; set; }
        /// <summary>
        /// 사운드 플래그를 설정하거나 취득할 수 있습니다.
        /// </summary>
        public Boolean SoundFlag { get; set; }
        /// <summary>
        /// 혈흔 플래그를 설정하거나 취득할 수 있습니다.
        /// </summary>
        public Boolean BloodFlag { get; set; }
        /// <summary>
        /// 화면 밝기를 설정하거나 취득할 수 있습니다.
        /// </summary>
        public Byte ScreenBrightness { get; set; }
        /// <summary>
        /// 마우스 반전 플래그를 설정하거나 취득할 수 있습니다.
        /// </summary>
        public Boolean InvertMouseFlag { get; set; }
        /// <summary>
        /// 프레임 스킵 플래그를 설정하거나 취득할 수 있습니다.
        /// </summary>
        public Boolean FrameSkipFlag { get; set; }
        /// <summary>
        /// 다른 건사이트 플래그를 설정하거나 취득할 수 있습니다.
        /// </summary>
        public Boolean AnotherGunsightFlag { get; set; }
        /// <summary>
        /// 플레이어 이름을 설정하거나 취득할 수 있습니다.
        /// </summary>
        public String PlayerName { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public Configuration() {
            GameControlKeyCode = new GameControlKeyCodes[TOTAL_GAME_CONTROL_KEY];
            MouseSensitivity = 0;
            FullScreenFlag = false;
            SoundFlag = false;
            BloodFlag = false;
            ScreenBrightness = 0;
            InvertMouseFlag = false;
            FrameSkipFlag = false;
            AnotherGunsightFlag = false;
            PlayerName = String.Empty;
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="file_path">게임 설정 파일의 경로</param>
        public Configuration(String file_path) {
            GameControlKeyCode = new GameControlKeyCodes[TOTAL_GAME_CONTROL_KEY];
            MouseSensitivity = 0;
            FullScreenFlag = false;
            SoundFlag = false;
            BloodFlag = false;
            ScreenBrightness = 0;
            InvertMouseFlag = false;
            FrameSkipFlag = false;
            AnotherGunsightFlag = false;
            PlayerName = String.Empty;

            if (LoadConfig(file_path) == false) {
                throw new FileLoadException("Failed to open file!");
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 게임 설정 파일을 불러옵니다.
        /// </summary>
        /// <param name="file_path">게임 설정 파일의 경로</param>
        /// <returns>성공(true), 실패(false)</returns>
        public bool LoadConfig(String file_path) {
            if (String.IsNullOrEmpty(file_path) == true) { return false; }
            if (File.Exists(file_path) == false) { return false; }

            // 파일 읽기
            using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader br = new BinaryReader(fs, System.Text.Encoding.Default)) {
                    // 게임 조작 키 코드
                    for (var i = 0; i < TOTAL_GAME_CONTROL_KEY; i++) {
                        GameControlKeyCode[i] = (GameControlKeyCodes)br.ReadByte();
                    }

                    // 마우스 감도
                    MouseSensitivity = br.ReadByte();

                    // 전체화면 플래그
                    FullScreenFlag = br.ReadBoolean();

                    // 사운드 플래그
                    SoundFlag = br.ReadBoolean();

                    // 혈흔 플래그
                    BloodFlag = br.ReadBoolean();

                    // 화면 밝기
                    ScreenBrightness = br.ReadByte();

                    // 마우스 반전 플래그
                    InvertMouseFlag = br.ReadBoolean();

                    // 프레임 스킵 플래그
                    FrameSkipFlag = br.ReadBoolean();

                    // 다른 건사이트 플래그
                    AnotherGunsightFlag = br.ReadBoolean();

                    // 플레이어 이름
                    char[] temp = br.ReadChars(MAX_PLAYER_NAME);
                    if (temp[MAX_PLAYER_NAME - 1] != '\0') {
                        temp[MAX_PLAYER_NAME - 1] = '\0';
                    }
                    PlayerName = new String(temp);
                }
            }

            return true;
        }

        /// <summary>
        /// 게임 설정 파일을 저장합니다.
        /// </summary>
        /// <param name="file_path">게임 설정 파일의 경로</param>
        /// <returns>성공(true), 실패(false)</returns>
        public bool SaveConfig(String file_path) {
            if (String.IsNullOrEmpty(file_path) == true) { return false; }

            using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write)) {
                using (BinaryWriter bw = new BinaryWriter(fs, System.Text.Encoding.Default)) {
                    // 게임 조작 키 코드
                    foreach (var code in GameControlKeyCode) {
                        bw.Write((Byte)code);
                    }

                    // 마우스 감도
                    bw.Write((Byte)MouseSensitivity);

                    // 전체화면 플래그
                    bw.Write((Boolean)FullScreenFlag);

                    // 사운드 플래그
                    bw.Write((Boolean)SoundFlag);

                    // 혈흔 플래그
                    bw.Write((Boolean)BloodFlag);

                    // 화면 밝기
                    bw.Write((Byte)ScreenBrightness);

                    // 마우스 반전 플래그
                    bw.Write((Boolean)InvertMouseFlag);

                    // 프레임 스킵 플래그
                    bw.Write((Boolean)FrameSkipFlag);

                    // 다른 건사이트 플래그
                    bw.Write((Boolean)AnotherGunsightFlag);

                    // 플레이어 이름
                    char[] temp = PlayerName.ToCharArray();
                    if (temp.Length >= MAX_PLAYER_NAME) {
                        if (temp[MAX_PLAYER_NAME - 1] != '\0') {
                            temp[MAX_PLAYER_NAME - 1] = '\0';
                        }
                        
                        bw.Write(temp, 0, MAX_PLAYER_NAME);
                    } else {
                        bw.Write(temp);
                    }
                }
            }
 
            return true;
        }

        /// <summary>
        /// 게임 설정 파일을 생성합니다.
        /// </summary>
        /// <param name="file_path">게임 설정 파일의 경로</param>
        /// <returns>성공(true), 실패(false)</returns>
        public bool CreateConfig(String file_path) {
            // if (String.IsNullOrEmpty(file_path) == true) { return false; }
            if (File.Exists(file_path) == true) { return false; }

            ResetConfigValue();
            return SaveConfig(file_path);
        }

        /// <summary>
        /// 게임 설정 값을 기본값으로 초기화합니다.
        /// </summary>
        public void ResetConfigValue() {
            if (GameControlKeyCode == null) { return; }

            GameControlKeyCode[(UInt32)GameControlKeys.TURN_UP] = GameControlKeyCodes.UP;
            GameControlKeyCode[(UInt32)GameControlKeys.TURN_DOWN] = GameControlKeyCodes.DOWN;
            GameControlKeyCode[(UInt32)GameControlKeys.TURN_LEFT] = GameControlKeyCodes.LEFT;
            GameControlKeyCode[(UInt32)GameControlKeys.TURN_RIGHT] = GameControlKeyCodes.RIGHT;
            GameControlKeyCode[(UInt32)GameControlKeys.MOVE_FORWARD] = GameControlKeyCodes.W;
            GameControlKeyCode[(UInt32)GameControlKeys.MOVE_BACKWARD] = GameControlKeyCodes.S;
            GameControlKeyCode[(UInt32)GameControlKeys.MOVE_LEFT] = GameControlKeyCodes.A;
            GameControlKeyCode[(UInt32)GameControlKeys.MOVE_RIGHT] = GameControlKeyCodes.D;
            GameControlKeyCode[(UInt32)GameControlKeys.WALK] = GameControlKeyCodes.TAB;
            GameControlKeyCode[(UInt32)GameControlKeys.JUMP] = GameControlKeyCodes.SPACE;
            GameControlKeyCode[(UInt32)GameControlKeys.RELOAD] = GameControlKeyCodes.R;
            GameControlKeyCode[(UInt32)GameControlKeys.DROP_WEAPON] = GameControlKeyCodes.G;
            GameControlKeyCode[(UInt32)GameControlKeys.ZOOM] = GameControlKeyCodes.SHIFT;
            GameControlKeyCode[(UInt32)GameControlKeys.SHOT_MODE] = GameControlKeyCodes.X;
            GameControlKeyCode[(UInt32)GameControlKeys.SWITCH_WEAPON] = GameControlKeyCodes.Z;
            GameControlKeyCode[(UInt32)GameControlKeys.WEAPON_1] = GameControlKeyCodes.D1;
            GameControlKeyCode[(UInt32)GameControlKeys.WEAPON_2] = GameControlKeyCodes.D2;
            GameControlKeyCode[(UInt32)GameControlKeys.SHOT] = GameControlKeyCodes.MOUSE_L;
            MouseSensitivity = 25;
            FullScreenFlag = true;
            SoundFlag = true;
            BloodFlag = true;
            ScreenBrightness = 4;
            InvertMouseFlag = false;
            FrameSkipFlag = false;
            AnotherGunsightFlag = false;
            PlayerName = DEFAULT_PLAYER_NAME;
        }
        #endregion
    }
}
