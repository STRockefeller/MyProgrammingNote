# flutter 基礎

[Reference:ITHelp](https://ithelp.ithome.com.tw/articles/10215158)

## 安裝 Flutter

### 下載

> 1. 安裝Git for Windows(https://git-scm.com/download/win)
> 2. 下載Flutter SDK
>    在C槽點滑鼠右鍵「Git bash here」，便會開啟git bash，你就可以在裡面下git command。
>    ![img](https://i.imgur.com/NmPVdgb.png)
>
> 接著輸入`git clone -b stable https://github.com/flutter/flutter.git`
> 電腦就會自己去找Flutter官方發布的最新穩定版本並下載到當前資料夾。
> ![img](https://i.imgur.com/ez6J5kc.png)

### 安裝

打開資料夾裡的flutter_console.bat，看到如下畫面

```powershell
######## ##       ##     ## ######## ######## ######## ########

##       ## ##

##       ## ##

######   ## ########

##       ## ##

##       ## ##

##       ######## ##


WELCOME to the Flutter Console.
===============================================================================

Use the console below this message to interact with the "flutter" command.
Run "flutter doctor" to check if your system is ready to run Flutter apps.
Run "flutter create <app_name>" to create a new Flutter project.

Run "flutter help" to see all available commands.

Want to use an IDE to interact with Flutter? https://flutter.dev/ide-setup/

Want to run the "flutter" command from any Command Prompt or PowerShell window?
Add Flutter to your PATH: https://flutter.dev/setup-windows/#update-your-path

===============================================================================

C:\Users\admin>
```



先照著做看看

> Run "flutter doctor" to check if your system is ready to run Flutter apps.

跑完如下

```powershell
C:\Users\admin>flutter doctor
Checking Dart SDK version...
Downloading Dart SDK from Flutter engine 2f0af3715217a0c2ada72c717d4ed9178d68f6ed...
Unzipping Dart SDK...
Building flutter tool...
Running pub upgrade...

╔════════════════════════════════════════════════════════════════════════════╗
║                 Welcome to Flutter! - https://flutter.dev                  ║
║                                                                            ║
║ The Flutter tool uses Google Analytics to anonymously report feature usage ║
║ statistics and basic crash reports. This data is used to help improve      ║
║ Flutter tools over time.                                                   ║
║                                                                            ║
║ Flutter tool analytics are not sent on the very first run. To disable      ║
║ reporting, type 'flutter config --no-analytics'. To display the current    ║
║ setting, type 'flutter config'. If you opt out of analytics, an opt-out    ║
║ event will be sent, and then no further information will be sent by the    ║
║ Flutter tool.                                                              ║
║                                                                            ║
║ By downloading the Flutter SDK, you agree to the Google Terms of Service.  ║
║ Note: The Google Privacy Policy describes how data is handled in this      ║
║ service.                                                                   ║
║                                                                            ║
║ Moreover, Flutter includes the Dart SDK, which may send usage metrics and  ║
║ crash reports to Google.                                                   ║
║                                                                            ║
║ Read about data we send with crash reports:                                ║
║ https://flutter.dev/docs/reference/crash-reporting                         ║
║                                                                            ║
║ See Google's privacy policy:                                               ║
║ https://policies.google.com/privacy                                        ║
╚════════════════════════════════════════════════════════════════════════════╝


Downloading Material fonts...                                       1.0s
Downloading Gradle Wrapper...                                       0.1s
Downloading package sky_engine...                                   0.7s
Downloading flutter_patched_sdk tools...                            5.0s
Downloading flutter_patched_sdk_product tools...                    4.0s
Downloading windows-x64 tools...                                    9.4s
Downloading windows-x64/font-subset tools...                        1.3s
Downloading android-arm-profile/windows-x64 tools...                0.7s
Downloading android-arm-release/windows-x64 tools...                0.8s
Downloading android-arm64-profile/windows-x64 tools...              1.2s
Downloading android-arm64-release/windows-x64 tools...              1.9s
Downloading android-x64-profile/windows-x64 tools...                0.6s
Downloading android-x64-release/windows-x64 tools...                0.6s
Doctor summary (to see all details, run flutter doctor -v):
[√] Flutter (Channel stable, 1.22.6, on Microsoft Windows [Version 10.0.18363.815], locale zh-TW)
[X] Android toolchain - develop for Android devices
 X Unable to locate Android SDK.
   Install Android Studio from: https://developer.android.com/studio/index.html
   On first launch it will assist you in installing the Android SDK components.
   (or visit https://flutter.dev/docs/get-started/install/windows#android-setup for detailed instructions).
   If the Android SDK has been installed to a custom location, set ANDROID_SDK_ROOT to that location.
   You may also want to add it to your PATH environment variable.

[!] Android Studio (not installed)
[!] VS Code
 X Flutter extension not installed; install from
   https://marketplace.visualstudio.com/items?itemName=Dart-Code.flutter
[!] Connected device
 ! No devices available

! Doctor found issues in 4 categories.
```



### 設定環境變數

使用者變數區域找到「path」變數，新增一個路徑到C:\flutter\bin (或其他路徑，看你下載到哪裡)

之後就能直接在CMD下flutter指令了



## Android studio

[載點](https://developer.android.com/studio)

註:本體容量將近1G，和VS一樣本體安裝完後還有一堆插件要裝。安裝過程漫長。



也有不安裝android直接取android sdk的作法，參考[這篇文章](https://abrialstha.medium.com/getting-started-with-flutter-without-android-studio-c7e1128330dd)，不過我還沒驗證過

### 設定模擬器

點一下右下「Configure」，選擇AVD Manager

設定完SIZE和API Level後就可以開啟了。



成功開啟模擬器後，再次執行`flutter doctor`

```powershell
C:\Users\admin>flutter doctor
Doctor summary (to see all details, run flutter doctor -v):
[√] Flutter (Channel stable, 1.22.6, on Microsoft Windows [Version 10.0.18363.815], locale zh-TW)

[!] Android toolchain - develop for Android devices (Android SDK version 30.0.3)
 X Android licenses not accepted.  To resolve this, run: flutter doctor --android-licenses
[!] Android Studio (version 4.1.0)
 X Flutter plugin not installed; this adds Flutter specific functionality.
 X Dart plugin not installed; this adds Dart specific functionality.
[!] VS Code
 X Flutter extension not installed; install from
   https://marketplace.visualstudio.com/items?itemName=Dart-Code.flutter
[√] Connected device (1 available)

! Doctor found issues in 3 categories.
```





### 安裝Flutter和dart plugin

好像可以透過android studio 或 VSC 進行編寫，這邊先照ITHELP的教學使用android studio試試看吧

Configure-->plugin 安裝flutter(會跳出安裝dart的提示，順便裝好)以及flutter snippets



這邊遇到一點小狀況，按照ITHELP的教學到這一步執行`flutter doctor`應該就不會有錯誤了

但是我這邊依然顯示我沒有安裝相關插件

```powershell
C:\Users\admin>flutter doctor
Doctor summary (to see all details, run flutter doctor -v):
[√] Flutter (Channel stable, 1.22.6, on Microsoft Windows [Version 10.0.18363.815], locale zh-TW)

[!] Android toolchain - develop for Android devices (Android SDK version 30.0.3)
 X Android licenses not accepted.  To resolve this, run: flutter doctor --android-licenses
[!] Android Studio (version 4.1.0)
 X Flutter plugin not installed; this adds Flutter specific functionality.
 X Dart plugin not installed; this adds Dart specific functionality.
[!] VS Code
 X Flutter extension not installed; install from
   https://marketplace.visualstudio.com/items?itemName=Dart-Code.flutter
[!] Connected device
 ! No devices available

! Doctor found issues in 4 categories.
```



確認過plugin裡面flutter 和 dart 都在installed那裏了。重新開啟android studio 或重啟電腦都沒有效果。

沒辦法，這邊先擱著，改用VSC試試看。

```pow
C:\Users\admin>flutter doctor
Doctor summary (to see all details, run flutter doctor -v):
[√] Flutter (Channel stable, 1.22.6, on Microsoft Windows [Version 10.0.18363.815], locale zh-TW)

[!] Android toolchain - develop for Android devices (Android SDK version 30.0.3)
 X Android licenses not accepted.  To resolve this, run: flutter doctor --android-licenses
[!] Android Studio (version 4.1.0)
 X Flutter plugin not installed; this adds Flutter specific functionality.
 X Dart plugin not installed; this adds Dart specific functionality.
[√] VS Code
[!] Connected device
 ! No devices available

! Doctor found issues in 3 categories.
```



VSC安裝完flutter之後有勾起來。



查明原因似乎是4.1.0版本的bug

按以下步驟

```powershell
step1 : run > flutter channel dev 

step2 : run > flutter channel updrade 

step3 : run > flutter config --android-studio-dir="C:\Program Files\Android\Android Studio"
```



執行結果，要跑滿久的

```powershell
C:\Users\admin>flutter channel dev
Switching to flutter channel 'dev'...
git: Branch 'dev' set up to track remote branch 'dev' from 'origin'.
git: Switched to a new branch 'dev'
Successfully switched to flutter channel 'dev'.
To ensure that you're on the latest build from this channel, run 'flutter upgrade'

C:\Users\admin>flutter channel updrade
Checking Dart SDK version...
Downloading Dart SDK from Flutter engine b04955656c87de0d80d259792e3a0e4a23b7c260...
Expanding downloaded archive...
Building flutter tool...
Running pub upgrade...
Downloading Material fonts...                                    1,295ms
Downloading Gradle Wrapper...                                       64ms
Downloading package sky_engine...                                  319ms
Downloading flutter_patched_sdk tools...                         2,488ms
Downloading flutter_patched_sdk_product tools...                 2,563ms
Downloading windows-x64 tools...                                    4.7s
Downloading windows-x64/font-subset tools...                       653ms
Switching to flutter channel 'updrade'...
This is not an official channel. For a list of available channels, try "flutter channel".
git: fatal: 'origin/updrade' is not a commit and a branch 'updrade' cannot be created from it
Switching channels failed with error code 128.

C:\Users\admin>flutter config --android-studio-dir="C:\Program Files\Android\Android Studio"
Setting "android-studio-dir" value to "C:\Program Files\Android\Android Studio".

You may need to restart any open editors for them to read new settings.
```



再跑一次`flutter doctor`

```powershell
C:\Users\admin>flutter doctor
Doctor summary (to see all details, run flutter doctor -v):
[√] Flutter (Channel dev, 1.27.0-1.0.pre, on Microsoft Windows [Version 10.0.18363.815], locale zh-TW)
[!] Android toolchain - develop for Android devices (Android SDK version 30.0.3)
 X Android licenses not accepted.  To resolve this, run: flutter doctor --android-licenses
[√] Chrome - develop for the web
[√] Android Studio (version 4.1.0)
[√] VS Code
[√] Connected device (1 available)

! Doctor found issues in 1 category.
```



很好，現在還差一個`Android toolchain`

### android toolchain

教學裡面這一項一開始就沒問題了，沒辦法只能自力更生

> Android licenses not accepted.  To resolve this, run: flutter doctor --android-licenses

先按照flutter doctor的提示做做看吧

執行`flutter doctor --android-licenses`

然後會跳出約五六個想是注意事項還是使用條款的內容詢問是否同意，反正是都同意了

最後看到這個

```powershell
Accept? (y/N): y
All SDK package licenses accepted
```



然後終於搞定了

```powershell
C:\Users\admin>flutter doctor
Doctor summary (to see all details, run flutter doctor -v):
[√] Flutter (Channel dev, 1.27.0-1.0.pre, on Microsoft Windows [Version 10.0.18363.815], locale zh-TW)
[√] Android toolchain - develop for Android devices (Android SDK version 30.0.3)
[√] Chrome - develop for the web
[√] Android Studio (version 4.1.0)
[√] VS Code
[√] Connected 

device (1 available)

• No issues found!
```



## Flutter Commands

這編列幾個常用指令，以下節錄自 [Flutter開發說明-Flutter開發環境架設](https://medium.com/mp-mobile-application-lab/flutter%E9%96%8B%E7%99%BC%E8%AA%AA%E6%98%8E-flutter%E9%96%8B%E7%99%BC%E7%92%B0%E5%A2%83%E6%9E%B6%E8%A8%AD-fb1c037759cd)

查詢版本：

```
$ flutter --version
```

更新Flutter：

```
$ flutter upgrade
```

查詢分支：

```
$ flutter channel
```

如果需要時可以變更channel、切換分支：

```
$ flutter channel dev
```

列出Flutter版本：

```
$ flutter version
```

切换到特定版本的 Flutter：

```
$ flutter version x.x.x
```

### 建立專案

建立專案時指定平台語言，iOS平台選擇Swift、Android平台選擇Kotlin。

```
$ flutter create --androidx --org your_organization -i swift -a kotlin myapp$ cd myapp
$ flutter run
```

### 語法說明：

- your_organization：使用反域名命名規範，全部使用小寫字母，例如：com.microprogram。
- myapp：App名稱使用小寫字母。

取得package：

```
$ flutter packages get
```

更新package：

```
$ flutter packages upgrade
```

