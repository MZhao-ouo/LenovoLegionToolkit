# Lenovo Legion Toolkit

[![Build](https://github.com/BartoszCichecki/LenovoLegionToolkit/actions/workflows/build.yml/badge.svg?branch=master)](https://github.com/BartoszCichecki/LenovoLegionToolkit/actions/workflows/build.yml) [![Join Discord](https://img.shields.io/discord/761178912230473768?label=Legion%20Series%20Discord)](https://discord.com/invite/legionseries)

# 📢📢📢官方仓库已发布语言切换功能，该仓库将不再维护，请前往[原项目](https://github.com/BartoszCichecki/LenovoLegionToolkit)查看最新动态

（该仓库为[Lenovo Legion Toolkit](https://github.com/BartoszCichecki/LenovoLegionToolkit)的中文翻译版本，目前还未完善。原项目也在开发动态切换语言的功能，完成后将合并。）

Lenovo Legion Toolkit（LLT）是为联想拯救者笔记本电脑打造的轻量工具集，可以实现联想全家桶（如：联想电脑管家、Legion Zone、Lenovo Vantage）中的大部分功能。

**目前仅完美适配拯救者和Ideapad Gaming系列机型，其他机型请自行测试，不承担任何后果**

该软件仅适用于Windows，无需安装OEM厂商的服务，内存占用小，几乎不占用CPU，并且不收集用户信息。实际工作方式类似Lenovo Vantage向硬件发出命令。

海外拯救者系列Discord群组: https://discord.com/invite/legionseries!

<img src="assets/screenshot.png" width="700" alt="PayPal QR code" />

# 目录
  - [免责声明](#免责声明)
  - [捐赠](#捐赠)
  - [下载](#下载)
  - [兼容性](#兼容性)
  - [功能介绍](#功能介绍)
  - [项目基础](#项目基础)
  - [FAQ](#faq)
  - [如何采集logs](#如何采集logs)
  - [贡献](#贡献)

## 免责声明

**该工具非联想官方提供，用户自行承担风险。**

这是作者的业余项目，并且作者希望该工具能够在更多设备上使用，但这需要花费时间和精力，如有不足之处请提出Issue或者耐心等待。该README请仔细阅读。

## 捐赠

如果这个项目对你有帮助，可以请作者喝杯咖啡~

<a href="https://www.paypal.com/donate/?hosted_button_id=22AZE2NBP3HTL"><img src="LenovoLegionToolkit.WPF/Assets/paypal_button.png" width="200" alt="PayPal Donate" /></a>

<img src="LenovoLegionToolkit.WPF/Assets/paypal_qr.png" width="200" alt="PayPal QR code" />

## 下载

你可以从这里下载安装包: [Latest release](https://github.com/MZhao-ouo/LenovoLegionToolkitCH/releases).

## 兼容性

Lenovo Legion Toolkit适用于绝大部分联想拯救者机型，包括2022、2021以及2022的机型，可运行于Windows10和Windows11。作者在搭载最新版Windows 11的Legion 5 Pro 16ACH6H（对应国内R9000P 2021）上完成调试。我在使用Y9000P 2022 Windows 11，全部功能可用。

LLT可能与联想的应用产生冲突，建议在使用时卸载或者禁用联想全家桶（Lenovo Vantage、Lenovo Hotkeys和Legion Zone）。LLT的设置界面提供了禁用的选项。

如果你在启动时看到不兼容提示的弹窗，可以查看文档底部的*贡献*部分，协助作者适配你的机型。作者会在未经测试的机器上弹窗并自动收集logs，联想机型众多，作者不可能亲自一个一个去试。

经测试支持的机型: [Compatibility.cs](https://github.com/BartoszCichecki/LenovoLegionToolkit/blob/master/LenovoLegionToolkit.Lib/Utils/Compatibility.cs).

暂时不考虑适配非Legion（拯救者）机型。

## 功能介绍

该软件可以做到:

- 调整电源模式、充电模式等只能在Lenovo Vantage（联想电脑管家）中实现的功能。
- 调整自定义模式，甚至可以调整风扇曲线（在2022机型上）等只能在Legion Zone中实现的功能。
- 完美支持键盘背光，包括4-zone RGB和白色背光。
- 更改刷新率（前提是你的屏幕支持）。
- 停用显卡（仅支持N卡）。
- 查看电池状态信息。
- 下载驱动、更新。
- 自动化：在插电或离电时自动执行设定好的操作集。
- 禁用/启用联想全家桶（Lenovo Vantage, Legion Zone和Lenovo Hotkeys service）且无需卸载。

##### 停用独显（dGPU）

禁用独显以提升续航。例如当你拔掉独显连接的显示器时，应用还可能运行在独显上，此时可以使用该功能。

有两种途径停用独显：

1. 杀死所有运行在dGPU上的App (这种方法似乎更有效)；
2. 短时间内禁用dGPU，让运行的应用转移到集显上。

当dGPU处于活动状态，启用混合模式，并且没有屏幕连接到dGPU时，停用按钮才会亮起。如果你将鼠标悬停在该按钮上，你会看到dGPU当前的状态以及在其上运行的进程列表。

注意：有些应用可能在停用独显时直接崩溃。

##### Windows电源计划

Lenovo Legion Toolkit能够自动在切换电源模式时切换Windows电源计划，*请保证*Lenovo Vantage已被禁用。

但在某些笔记本上，Lenovo Vantage并不会切换电源计划。如果你的Lenovo Vantage不会自动切换的话，可以在设置里手动选择不同电源模式对应的电源计划。此时你可以把Vantage挂在后台。

##### CPU提升模式

此选项可以修改Windows电源计划中的隐藏设置——*处理器性能提升模式*。这个名称和选项可能有点费解，好在微软提供了文档你可以看看:

[Power and performance tuning @microsoft.com](https://docs.microsoft.com/en-us/windows-server/administration/performance-tuning/hardware/power/power-performance-tuning#processor-performance-boost-mode)

[ProcessorPerformanceBoostMode @microsoft.com](https://docs.microsoft.com/en-us/dotnet/api/microsoft.windows.eventtracing.power.processorperformanceboostmode?view=trace-processor-dotnet-1.0)

## 项目基础

特别感谢:

* LLT的基础 —— [ViRb3](https://github.com/ViRb3) —— [Lenovo Controller](https://github.com/ViRb3/LenovoController)
* 显示相关 —— [falahati](https://github.com/falahati) —— [NvAPIWrapper](https://github.com/falahati/NvAPIWrapper) 、 [WindowsDisplayAPI](https://github.com/falahati/WindowsDisplayAPI)
* 4-zone RGB键盘背光 —— [SmokelessCPU](https://github.com/SmokelessCPU)

## FAQ

#### 如何禁用兼容性检查？

在`%LOCALAPPDATA%\LenovoLegionToolkit`创建`args.txt`文件，并在文件中输入`--skip-compat-check`，该操作将禁用LLT的所有兼容性检查。请勿滥用此操作。

#### LLT开机自启失败？

LLT用计划任务实现开机自启，这样可以保证应用的管理员权限。开机后1分钟（2.4.0及以上版本为30s）自启来保证其他应用先启动。如果1分钟后还是没有启动，请提交Issue。

#### 主板换了，LLT提示不兼容的弹窗。我该怎么办？

有时新主板的机型和序列号信息可能不正确，尝试[这篇教程](https://laptopwiki.eu/index.php/guides-and-tutorials/important-bios-related-guides/recover-original-model-sku-values/)来恢复。如果这个方法不起作用，请到`%LOCALAPPDATA%\LenovoLegionToolkit`创建`args.txt`文件，并在文件中输入`--skip-compat-check`，该操作将禁用LLT的所有兼容性检查。请勿滥用此操作。

#### 找不到AI引擎的选项？

不支持AI引擎。AI引擎依赖联想的服务。

#### 支持哪些RGB类型？

目前仅支持白色背光和4-zone RGB。

#### 是否支持iCue RGB keyboards?

不支持。请查阅[OpenRGB](https://openrgb.org/)项目。

#### 是否支持Legion Spectrum RGB keyboards（联想的某个键盘）?

作者想要适配但是并没有这个键盘（疯狂暗示）。欢迎提交PR。

#### 是否有更多的RGB效果？

只有硬件本身支持的选项是可用的，并且不计划添加自定义选项。如果你非常想要自定义RGB可以看看[L5P-Keyboard-RGB](https://github.com/4JX/L5P-Keyboard-RGB) 或 [OpenRGB](https://openrgb.org/).

#### 能否让其他机型支持自定义风扇曲线？

2022款可以，早些时候的机器不行。


## 如何采集logs？

如果遇到问题请提交los，这将会超超超超超级有用。

采集logs的步骤:

1. 确保LLT不在运行（托盘区也不能存）；
2. 使用`Win+R`打开"运行"，输入: `"%LOCALAPPDATA%\Programs\LenovoLegionToolkit\Lenovo Legion Toolkit.exe" --trace`并确认；
3. LLT将启动，并在标题栏显示: `[LOGGING ENABLED]`
4. 复现你遇到的问题；
5. 关闭LLT（托盘区也不能留）；
6. 再用`Win+R`并输入`"%LOCALAPPDATA%\LenovoLegionToolkit\log"`；
7. 这里就是存放log文件的地方了，提Issue时记得附上。



2.6.0及以上版本采集logs更简单：

1. 确保LLT不在运行（托盘区也不能存）；
2. 按住`ctrl`和`shift`；
3. 双击Lenovo Legion Toolkit图标；
4. LLT将启动，并在标题栏显示: `[LOG]`，点一下就能看到当前的log文件了。


## 贡献

感谢你们的所有反馈，请不要犹豫提交Issue。我们也欢迎PR。

#### Bugs

如果你发现了任何bugs，请提交Issue告诉我。最好再附上logs，这对我修复bug有巨大帮助。logs的文件夹在`%LOCALAPPDATA%\LenovoLegionToolkit\log`。

#### 兼容性

我非常乐意适配更多的机型，但要做到这点需要你的帮助！

如果你乐意在未适配机型上测试该软件，请在弹窗界面点击_继续_，LLT将会自动记录logs以便于遇到问题时提交。

*请记住某些功能可能无法正常运行*

如果你在github issue提交了你的测试结果，我将非常感激。

请确保你的issue中包含以下内容：

1. 机型全称 (例如 Legion 5 Pro 16ACH6H)
2. 可以正常工作的功能。
3. 似乎不起作用的功能。
4. 导致崩溃的功能。

你提交的信息越多，该项目会变得更加完善。如果有什么问题请写下详情并附上log
(log文件夹`%LOCALAPPDATA%\LenovoLegionToolkit\log`)。


十分感谢！！！
