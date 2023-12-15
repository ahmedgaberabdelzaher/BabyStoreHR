; ModuleID = 'obj/Release/android/marshal_methods.armeabi-v7a.ll'
source_filename = "obj/Release/android/marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [288 x i32] [
	i32 34715100, ; 0: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 132
	i32 39109920, ; 1: Newtonsoft.Json.dll => 0x254c520 => 81
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 126
	i32 82002252, ; 3: Syncfusion.SfRangeSlider.XForms.Android.dll => 0x4e3414c => 109
	i32 99966887, ; 4: Xamarin.Firebase.Iid.dll => 0x5f55fa7 => 124
	i32 113478513, ; 5: Syncfusion.SfRangeSlider.XForms.dll => 0x6c38b71 => 110
	i32 122350210, ; 6: System.Threading.Channels.dll => 0x74aea82 => 116
	i32 164065134, ; 7: Unity.Abstractions => 0x9c76f6e => 117
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 31
	i32 221063263, ; 9: Microsoft.AspNetCore.Http.Connections.Client => 0xd2d285f => 64
	i32 229731493, ; 10: Huawei.Hms.NetworkGrs => 0xdb16ca5 => 57
	i32 230752869, ; 11: Microsoft.CSharp.dll => 0xdc10265 => 5
	i32 232815796, ; 12: System.Web.Services => 0xde07cb4 => 37
	i32 317030064, ; 13: Plugin.SharedTransitions.dll => 0x12e57eb0 => 87
	i32 318968648, ; 14: Xamarin.AndroidX.Activity.dll => 0x13031348 => 119
	i32 321597661, ; 15: System.Numerics => 0x132b30dd => 12
	i32 332531999, ; 16: Syncfusion.SfBusyIndicator.XForms.Android => 0x13d2091f => 102
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 26
	i32 348048101, ; 18: Microsoft.AspNetCore.Http.Connections.Common.dll => 0x14becae5 => 65
	i32 394611635, ; 19: Syncfusion.SfPdfViewer.XForms => 0x17854bb3 => 105
	i32 442521989, ; 20: Xamarin.Essentials => 0x1a605985 => 122
	i32 450948140, ; 21: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 24
	i32 458494020, ; 22: Microsoft.AspNetCore.SignalR.Common.dll => 0x1b541044 => 69
	i32 465846621, ; 23: mscorlib => 0x1bc4415d => 7
	i32 469710990, ; 24: System.dll => 0x1bff388e => 10
	i32 501000162, ; 25: Prism.dll => 0x1ddca7e2 => 90
	i32 507185320, ; 26: NGraphics.Android.Custom.dll => 0x1e3b08a8 => 82
	i32 513247710, ; 27: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 77
	i32 516934521, ; 28: Huawei.Android.Hms.SecurityBase => 0x1ecfcb79 => 47
	i32 535134469, ; 29: Syncfusion.SfBusyIndicator.Android => 0x1fe58105 => 101
	i32 536396994, ; 30: SVG.Forms.Plugin.Android.dll => 0x1ff8c4c2 => 95
	i32 539058512, ; 31: Microsoft.Extensions.Logging => 0x20216150 => 75
	i32 548916678, ; 32: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 71
	i32 574378164, ; 33: XamSvg.Droid.dll => 0x223c50b4 => 141
	i32 623623227, ; 34: HrApp => 0x252bbc3b => 45
	i32 627609679, ; 35: Xamarin.AndroidX.CustomView => 0x2568904f => 22
	i32 662205335, ; 36: System.Text.Encodings.Web.dll => 0x27787397 => 114
	i32 663517072, ; 37: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 33
	i32 665787137, ; 38: Huawei.Hms.Log.dll => 0x27af1b01 => 55
	i32 690569205, ; 39: System.Xml.Linq.dll => 0x29293ff5 => 15
	i32 700284507, ; 40: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 135
	i32 702630279, ; 41: Huawei.Hms.NetworkGrs.dll => 0x29e14987 => 57
	i32 719061231, ; 42: Syncfusion.Core.XForms.dll => 0x2adc00ef => 98
	i32 767728125, ; 43: Syncfusion.SfPdfViewer.XForms.dll => 0x2dc299fd => 105
	i32 775623772, ; 44: AiForms.Effects => 0x2e3b145c => 42
	i32 782533833, ; 45: Xamarin.Google.AutoValue.Annotations.dll => 0x2ea484c9 => 131
	i32 789151979, ; 46: Microsoft.Extensions.Options => 0x2f0980eb => 76
	i32 809851609, ; 47: System.Drawing.Common.dll => 0x30455ad9 => 1
	i32 832711436, ; 48: Microsoft.AspNetCore.SignalR.Protocols.Json.dll => 0x31a22b0c => 70
	i32 855944274, ; 49: NGraphics.Custom => 0x3304ac52 => 83
	i32 910284651, ; 50: Syncfusion.SfRangeSlider.XForms => 0x3641d76b => 110
	i32 926997726, ; 51: Plugin.Multilingual.Abstractions => 0x3740dcde => 85
	i32 928116545, ; 52: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 132
	i32 934055265, ; 53: Huawei.Hms.Push.dll => 0x37ac8d61 => 59
	i32 955402788, ; 54: Newtonsoft.Json => 0x38f24a24 => 81
	i32 967690846, ; 55: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 26
	i32 974778368, ; 56: FormsViewGroup.dll => 0x3a19f000 => 44
	i32 1012816738, ; 57: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 120
	i32 1028951442, ; 58: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 72
	i32 1035644815, ; 59: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 17
	i32 1042160112, ; 60: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 129
	i32 1052210849, ; 61: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 28
	i32 1058641855, ; 62: Microsoft.AspNetCore.Http.Connections.Common => 0x3f1997bf => 65
	i32 1061503568, ; 63: Xamarin.Google.AutoValue.Annotations => 0x3f454250 => 131
	i32 1084122840, ; 64: Xamarin.Kotlin.StdLib => 0x409e66d8 => 137
	i32 1098259244, ; 65: System => 0x41761b2c => 10
	i32 1127295045, ; 66: Polly.dll => 0x43312845 => 89
	i32 1139625163, ; 67: SVG.Forms.Plugin.Abstractions.dll => 0x43ed4ccb => 94
	i32 1149099989, ; 68: Huawei.Android.Hms.SecuritySsl => 0x447ddfd5 => 49
	i32 1218518409, ; 69: Prism.Unity.Forms.dll => 0x48a11d89 => 92
	i32 1233093933, ; 70: Microsoft.AspNetCore.SignalR.Client.Core.dll => 0x497f852d => 67
	i32 1264538220, ; 71: Syncfusion.Compression.Portable => 0x4b5f526c => 96
	i32 1293217323, ; 72: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 23
	i32 1309284514, ; 73: Plugin.FirebasePushNotification => 0x4e0a18a2 => 84
	i32 1333047053, ; 74: Xamarin.Firebase.Common => 0x4f74af0d => 123
	i32 1345695187, ; 75: Syncfusion.SfRangeSlider.XForms.Android => 0x5035add3 => 109
	i32 1365406463, ; 76: System.ServiceModel.Internals.dll => 0x516272ff => 38
	i32 1376866003, ; 77: Xamarin.AndroidX.SavedState => 0x52114ed3 => 120
	i32 1380977605, ; 78: Huawei.Hms.Stats.dll => 0x52500bc5 => 60
	i32 1406073936, ; 79: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 19
	i32 1411638395, ; 80: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 13
	i32 1414043276, ; 81: Microsoft.AspNetCore.Connections.Abstractions.dll => 0x5448968c => 63
	i32 1440999970, ; 82: Unity.Container => 0x55e3ea22 => 118
	i32 1449961411, ; 83: Huawei.Hms.Base => 0x566ca7c3 => 52
	i32 1460219004, ; 84: Xamarin.Forms.Xaml => 0x57092c7c => 130
	i32 1460893475, ; 85: System.IdentityModel.Tokens.Jwt => 0x57137723 => 112
	i32 1464784794, ; 86: Syncfusion.SfPdfViewer.XForms.Android => 0x574ed79a => 104
	i32 1469204771, ; 87: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 16
	i32 1470490898, ; 88: Microsoft.Extensions.Primitives => 0x57a5e912 => 77
	i32 1498168481, ; 89: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 78
	i32 1516315406, ; 90: Syncfusion.Core.XForms.Android.dll => 0x5a61230e => 97
	i32 1519760047, ; 91: Syncfusion.SfProgressBar.XForms.Android.dll => 0x5a95b2af => 106
	i32 1522103383, ; 92: Huawei.Hms.Device.dll => 0x5ab97457 => 53
	i32 1533253840, ; 93: Syncfusion.SfBusyIndicator.Android.dll => 0x5b6398d0 => 101
	i32 1566488712, ; 94: Syncfusion.SfBusyIndicator.XForms.dll => 0x5d5eb888 => 103
	i32 1582821230, ; 95: Huawei.Android.Hms.SecuritySsl.dll => 0x5e57ef6e => 49
	i32 1592978981, ; 96: System.Runtime.Serialization.dll => 0x5ef2ee25 => 3
	i32 1612218441, ; 97: XamSvg.XamForms => 0x60188049 => 143
	i32 1615464666, ; 98: Huawei.Hms.Log => 0x604a08da => 55
	i32 1622152042, ; 99: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 29
	i32 1635860875, ; 100: Syncfusion.SfRangeSlider.Android => 0x6181418b => 108
	i32 1636350590, ; 101: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 21
	i32 1637556708, ; 102: Syncfusion.SfProgressBar.XForms.dll => 0x619b21e4 => 107
	i32 1639085333, ; 103: Huawei.Hms.Base.dll => 0x61b27515 => 52
	i32 1639515021, ; 104: System.Net.Http.dll => 0x61b9038d => 11
	i32 1658251792, ; 105: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 35
	i32 1663500400, ; 106: Huawei.Hmf.Tasks => 0x63270070 => 50
	i32 1698840827, ; 107: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 136
	i32 1706062090, ; 108: XamSvg.Shared => 0x65b0710a => 142
	i32 1729485958, ; 109: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 18
	i32 1739193536, ; 110: NGraphics.Android.Custom => 0x67a9fcc0 => 82
	i32 1740319209, ; 111: Huawei.Hms.Hatool => 0x67bb29e9 => 54
	i32 1746115085, ; 112: System.IO.Pipelines.dll => 0x68139a0d => 113
	i32 1766324549, ; 113: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 31
	i32 1770582343, ; 114: Microsoft.Extensions.Logging.dll => 0x6988f147 => 75
	i32 1776026572, ; 115: System.Core.dll => 0x69dc03cc => 9
	i32 1788241197, ; 116: Xamarin.AndroidX.Fragment => 0x6a96652d => 24
	i32 1796167890, ; 117: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 71
	i32 1808609942, ; 118: Xamarin.AndroidX.Loader => 0x6bcd3296 => 29
	i32 1813058853, ; 119: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 137
	i32 1813201214, ; 120: Xamarin.Google.Android.Material => 0x6c13413e => 35
	i32 1819327070, ; 121: Microsoft.AspNetCore.Http.Features.dll => 0x6c70ba5e => 66
	i32 1828688058, ; 122: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 74
	i32 1835480782, ; 123: XamSvg.Droid => 0x6d6736ce => 141
	i32 1849271627, ; 124: Prism.Forms.dll => 0x6e39a54b => 91
	i32 1867746548, ; 125: Xamarin.Essentials.dll => 0x6f538cf4 => 122
	i32 1878053835, ; 126: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 130
	i32 1905322901, ; 127: Huawei.Hms.Opendevice.dll => 0x7190eb95 => 58
	i32 1908813208, ; 128: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 133
	i32 1917312288, ; 129: AiForms.Effects.Droid.dll => 0x7247dd20 => 43
	i32 1933215285, ; 130: Xamarin.Firebase.Messaging.dll => 0x733a8635 => 125
	i32 1945717188, ; 131: Microsoft.AspNetCore.SignalR.Client.Core => 0x73f949c4 => 67
	i32 1967334205, ; 132: Microsoft.AspNetCore.SignalR.Common => 0x7543233d => 69
	i32 1974606741, ; 133: NGraphics.Custom.dll => 0x75b21b95 => 83
	i32 1983156543, ; 134: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 136
	i32 1986222447, ; 135: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 80
	i32 2011961780, ; 136: System.Buffers.dll => 0x77ec19b4 => 8
	i32 2019465201, ; 137: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 28
	i32 2055257422, ; 138: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 27
	i32 2059619953, ; 139: Plugin.SharedTransitions => 0x7ac34e71 => 87
	i32 2065833063, ; 140: Unity.Container.dll => 0x7b221c67 => 118
	i32 2066202781, ; 141: Prism => 0x7b27c09d => 90
	i32 2066297753, ; 142: Huawei.Hms.Availableupdate.dll => 0x7b293399 => 51
	i32 2077425357, ; 143: Huawei.Hms.Stats => 0x7bd2fecd => 60
	i32 2079627543, ; 144: Plugin.Multilingual.dll => 0x7bf49917 => 86
	i32 2097448633, ; 145: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 25
	i32 2113902067, ; 146: Xamarin.Forms.PancakeView.dll => 0x7dff95f3 => 127
	i32 2126786730, ; 147: Xamarin.Forms.Platform.Android => 0x7ec430aa => 128
	i32 2147356122, ; 148: Huawei.Android.Hms.SecurityBase.dll => 0x7ffe0dda => 47
	i32 2181898931, ; 149: Microsoft.Extensions.Options.dll => 0x820d22b3 => 76
	i32 2192057212, ; 150: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 74
	i32 2201231467, ; 151: System.Net.Http => 0x8334206b => 11
	i32 2223043141, ; 152: Huawei.Hmf.Tasks.dll => 0x8480f245 => 50
	i32 2279755925, ; 153: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 30
	i32 2319144366, ; 154: Microsoft.AspNetCore.SignalR.Client => 0x8a3b55ae => 68
	i32 2343171156, ; 155: Syncfusion.Core.XForms => 0x8ba9f454 => 98
	i32 2354730003, ; 156: Syncfusion.Licensing => 0x8c5a5413 => 99
	i32 2369706906, ; 157: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 79
	i32 2373047941, ; 158: XamForms.Controls.Calendar.Droid => 0x8d71d685 => 139
	i32 2397082276, ; 159: Xamarin.Forms.PancakeView => 0x8ee092a4 => 127
	i32 2452282595, ; 160: Syncfusion.SfPdfViewer.XForms.Android.dll => 0x922adce3 => 104
	i32 2467049111, ; 161: Huawei.Agconnect.AgconnectCore => 0x930c2e97 => 46
	i32 2471215200, ; 162: ImageCircle.Forms.Plugin => 0x934bc060 => 62
	i32 2475788418, ; 163: Java.Interop.dll => 0x93918882 => 4
	i32 2483742551, ; 164: Xamarin.Firebase.Messaging => 0x940ae757 => 125
	i32 2562349572, ; 165: Microsoft.CSharp => 0x98ba5a04 => 5
	i32 2570120770, ; 166: System.Text.Encodings.Web => 0x9930ee42 => 114
	i32 2578279760, ; 167: XamSvg.XamForms.dll => 0x99ad6d50 => 143
	i32 2620871830, ; 168: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 21
	i32 2640290731, ; 169: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 79
	i32 2644307787, ; 170: Huawei.Hms.Availableupdate => 0x9d9cef4b => 51
	i32 2727552820, ; 171: Huawei.Hms.Device => 0xa2932734 => 53
	i32 2732626843, ; 172: Xamarin.AndroidX.Activity => 0xa2e0939b => 119
	i32 2735172069, ; 173: System.Threading.Channels => 0xa30769e5 => 116
	i32 2737747696, ; 174: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 16
	i32 2763696748, ; 175: Syncfusion.SfRangeSlider.Android.dll => 0xa4baaa6c => 108
	i32 2765824710, ; 176: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 2
	i32 2766581644, ; 177: Xamarin.Forms.Core => 0xa4e6af8c => 126
	i32 2770495804, ; 178: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 135
	i32 2778768386, ; 179: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 34
	i32 2810250172, ; 180: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 19
	i32 2819470561, ; 181: System.Xml.dll => 0xa80db4e1 => 14
	i32 2850549256, ; 182: Microsoft.AspNetCore.Http.Features => 0xa9e7ee08 => 66
	i32 2853208004, ; 183: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 34
	i32 2854891590, ; 184: Syncfusion.SfProgressBar.XForms => 0xaa2a3046 => 107
	i32 2855708567, ; 185: Xamarin.AndroidX.Transition => 0xaa36a797 => 32
	i32 2868557005, ; 186: Syncfusion.Licensing.dll => 0xaafab4cd => 99
	i32 2870995654, ; 187: Xamarin.Firebase.Iid => 0xab1feac6 => 124
	i32 2874148507, ; 188: Syncfusion.Core.XForms.Android => 0xab50069b => 97
	i32 2875347124, ; 189: Microsoft.AspNetCore.Http.Connections.Client.dll => 0xab6250b4 => 64
	i32 2886109683, ; 190: Syncfusion.SfBusyIndicator.XForms.Android.dll => 0xac0689f3 => 102
	i32 2905242038, ; 191: mscorlib.dll => 0xad2a79b6 => 7
	i32 2917517763, ; 192: Plugin.XamarinFormsSaveOpenPDFPackage.dll => 0xade5c9c3 => 88
	i32 2923486322, ; 193: Prism.Unity.Forms => 0xae40dc72 => 92
	i32 2934963324, ; 194: HrApp.dll => 0xaeeffc7c => 45
	i32 2965194746, ; 195: Huawei.Hms.NetworkCommon => 0xb0bd47fa => 56
	i32 2978675010, ; 196: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 23
	i32 3020614608, ; 197: XamSvg.Abstractions => 0xb40aebd0 => 140
	i32 3044182254, ; 198: FormsViewGroup => 0xb57288ee => 44
	i32 3058099980, ; 199: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 134
	i32 3071899978, ; 200: Xamarin.Firebase.Common.dll => 0xb719794a => 123
	i32 3084678329, ; 201: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 80
	i32 3111772706, ; 202: System.Runtime.Serialization => 0xb979e222 => 3
	i32 3124832203, ; 203: System.Threading.Tasks.Extensions => 0xba4127cb => 40
	i32 3196832649, ; 204: Plugin.Multilingual => 0xbe8bcb89 => 86
	i32 3204380047, ; 205: System.Data.dll => 0xbefef58f => 36
	i32 3230466174, ; 206: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 133
	i32 3247949154, ; 207: Mono.Security => 0xc197c562 => 39
	i32 3248508112, ; 208: HrApp.Android.dll => 0xc1a04cd0 => 41
	i32 3249260365, ; 209: RestSharp.dll => 0xc1abc74d => 93
	i32 3258312781, ; 210: Xamarin.AndroidX.CardView => 0xc235e84d => 18
	i32 3265893370, ; 211: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 40
	i32 3273112673, ; 212: Huawei.Hms.NetworkCommon.dll => 0xc317bc61 => 56
	i32 3288844784, ; 213: Huawei.Android.Hms.SecurityEncrypt => 0xc407c9f0 => 48
	i32 3312457198, ; 214: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 78
	i32 3317135071, ; 215: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 22
	i32 3317144872, ; 216: System.Data => 0xc5b79d28 => 36
	i32 3321792619, ; 217: XamSvg.Abstractions.dll => 0xc5fe886b => 140
	i32 3353484488, ; 218: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 25
	i32 3353544232, ; 219: Xamarin.CommunityToolkit.dll => 0xc7e30628 => 121
	i32 3358260929, ; 220: System.Text.Json => 0xc82afec1 => 115
	i32 3362522851, ; 221: Xamarin.AndroidX.Core => 0xc86c06e3 => 20
	i32 3366347497, ; 222: Java.Interop => 0xc8a662e9 => 4
	i32 3374517072, ; 223: Plugin.XamarinFormsSaveOpenPDFPackage => 0xc9230b50 => 88
	i32 3374999561, ; 224: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 30
	i32 3395150330, ; 225: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 13
	i32 3401559547, ; 226: Plugin.FirebasePushNotification.dll => 0xcabfadfb => 84
	i32 3404865022, ; 227: System.ServiceModel.Internals => 0xcaf21dfe => 38
	i32 3407215217, ; 228: Xamarin.CommunityToolkit => 0xcb15fa71 => 121
	i32 3428513518, ; 229: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 73
	i32 3429136800, ; 230: System.Xml => 0xcc6479a0 => 14
	i32 3433996769, ; 231: Syncfusion.Pdf.Portable.dll => 0xccaea1e1 => 100
	i32 3448896322, ; 232: Polly => 0xcd91fb42 => 89
	i32 3460255358, ; 233: Syncfusion.SfBusyIndicator.XForms => 0xce3f4e7e => 103
	i32 3466904072, ; 234: Microsoft.AspNetCore.SignalR.Client.dll => 0xcea4c208 => 68
	i32 3476120550, ; 235: Mono.Android => 0xcf3163e6 => 6
	i32 3483112796, ; 236: ImageCircle.Forms.Plugin.dll => 0xcf9c155c => 62
	i32 3484999123, ; 237: SVG.Forms.Plugin.Abstractions => 0xcfb8ddd3 => 94
	i32 3485117614, ; 238: System.Text.Json.dll => 0xcfbaacae => 115
	i32 3509114376, ; 239: System.Xml.Linq => 0xd128d608 => 15
	i32 3534510610, ; 240: Huawei.Android.Hms.SecurityEncrypt.dll => 0xd2ac5a12 => 48
	i32 3536029504, ; 241: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 128
	i32 3544322670, ; 242: Syncfusion.SfProgressBar.XForms.Android => 0xd342126e => 106
	i32 3549863983, ; 243: Huawei.Hms.Ui.dll => 0xd396a02f => 61
	i32 3551972787, ; 244: Syncfusion.Compression.Portable.dll => 0xd3b6cdb3 => 96
	i32 3579529003, ; 245: Huawei.Hms.Ui => 0xd55b472b => 61
	i32 3586971312, ; 246: XamForms.Controls.Calendar.Droid.dll => 0xd5ccd6b0 => 139
	i32 3596054127, ; 247: HrApp.resources.dll => 0xd6576e6f => 0
	i32 3632359727, ; 248: Xamarin.Forms.Platform => 0xd881692f => 129
	i32 3641597786, ; 249: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 27
	i32 3644908295, ; 250: HrApp.Android => 0xd940e307 => 41
	i32 3669463323, ; 251: HrApp.resources => 0xdab7911b => 0
	i32 3672681054, ; 252: Mono.Android.dll => 0xdae8aa5e => 6
	i32 3676310014, ; 253: System.Web.Services.dll => 0xdb2009fe => 37
	i32 3689375977, ; 254: System.Drawing.Common => 0xdbe768e9 => 1
	i32 3691870036, ; 255: Microsoft.AspNetCore.SignalR.Protocols.Json => 0xdc0d7754 => 70
	i32 3716573645, ; 256: AiForms.Effects.Droid => 0xdd8669cd => 43
	i32 3733882439, ; 257: Unity.Abstractions.dll => 0xde8e8647 => 117
	i32 3748608112, ; 258: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 111
	i32 3754700086, ; 259: Plugin.Multilingual.Abstractions.dll => 0xdfcc2d36 => 85
	i32 3787005001, ; 260: Microsoft.AspNetCore.Connections.Abstractions => 0xe1b91c49 => 63
	i32 3816437471, ; 261: RestSharp => 0xe37a36df => 93
	i32 3829621856, ; 262: System.Numerics.dll => 0xe4436460 => 12
	i32 3841636137, ; 263: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 72
	i32 3871651808, ; 264: AiForms.Effects.dll => 0xe6c4b7e0 => 42
	i32 3885922214, ; 265: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 32
	i32 3896760992, ; 266: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 20
	i32 3921031405, ; 267: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 33
	i32 3953953790, ; 268: System.Text.Encoding.CodePages => 0xebac8bfe => 2
	i32 3955647286, ; 269: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 17
	i32 3970018735, ; 270: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 134
	i32 3975321146, ; 271: Huawei.Hms.Opendevice => 0xecf2963a => 58
	i32 3979229314, ; 272: Huawei.Hms.Hatool.dll => 0xed2e3882 => 54
	i32 4002401680, ; 273: XamSvg.Shared.dll => 0xee8fcd90 => 142
	i32 4004187228, ; 274: Huawei.Hms.Push => 0xeeab0c5c => 59
	i32 4014908255, ; 275: XamForms.Controls.Calendar => 0xef4ea35f => 138
	i32 4023392905, ; 276: System.IO.Pipelines => 0xefd01a89 => 113
	i32 4050386365, ; 277: SVG.Forms.Plugin.Android => 0xf16bfdbd => 95
	i32 4085261167, ; 278: Prism.Forms => 0xf380236f => 91
	i32 4105002889, ; 279: Mono.Security.dll => 0xf4ad5f89 => 39
	i32 4126470640, ; 280: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 73
	i32 4151237749, ; 281: System.Core => 0xf76edc75 => 9
	i32 4213026141, ; 282: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 111
	i32 4220811361, ; 283: XamForms.Controls.Calendar.dll => 0xfb947861 => 138
	i32 4221941870, ; 284: Syncfusion.Pdf.Portable => 0xfba5b86e => 100
	i32 4260525087, ; 285: System.Buffers => 0xfdf2741f => 8
	i32 4263231520, ; 286: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 112
	i32 4293620108 ; 287: Huawei.Agconnect.AgconnectCore.dll => 0xffeb718c => 46
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [288 x i32] [
	i32 132, i32 81, i32 126, i32 109, i32 124, i32 110, i32 116, i32 117, ; 0..7
	i32 31, i32 64, i32 57, i32 5, i32 37, i32 87, i32 119, i32 12, ; 8..15
	i32 102, i32 26, i32 65, i32 105, i32 122, i32 24, i32 69, i32 7, ; 16..23
	i32 10, i32 90, i32 82, i32 77, i32 47, i32 101, i32 95, i32 75, ; 24..31
	i32 71, i32 141, i32 45, i32 22, i32 114, i32 33, i32 55, i32 15, ; 32..39
	i32 135, i32 57, i32 98, i32 105, i32 42, i32 131, i32 76, i32 1, ; 40..47
	i32 70, i32 83, i32 110, i32 85, i32 132, i32 59, i32 81, i32 26, ; 48..55
	i32 44, i32 120, i32 72, i32 17, i32 129, i32 28, i32 65, i32 131, ; 56..63
	i32 137, i32 10, i32 89, i32 94, i32 49, i32 92, i32 67, i32 96, ; 64..71
	i32 23, i32 84, i32 123, i32 109, i32 38, i32 120, i32 60, i32 19, ; 72..79
	i32 13, i32 63, i32 118, i32 52, i32 130, i32 112, i32 104, i32 16, ; 80..87
	i32 77, i32 78, i32 97, i32 106, i32 53, i32 101, i32 103, i32 49, ; 88..95
	i32 3, i32 143, i32 55, i32 29, i32 108, i32 21, i32 107, i32 52, ; 96..103
	i32 11, i32 35, i32 50, i32 136, i32 142, i32 18, i32 82, i32 54, ; 104..111
	i32 113, i32 31, i32 75, i32 9, i32 24, i32 71, i32 29, i32 137, ; 112..119
	i32 35, i32 66, i32 74, i32 141, i32 91, i32 122, i32 130, i32 58, ; 120..127
	i32 133, i32 43, i32 125, i32 67, i32 69, i32 83, i32 136, i32 80, ; 128..135
	i32 8, i32 28, i32 27, i32 87, i32 118, i32 90, i32 51, i32 60, ; 136..143
	i32 86, i32 25, i32 127, i32 128, i32 47, i32 76, i32 74, i32 11, ; 144..151
	i32 50, i32 30, i32 68, i32 98, i32 99, i32 79, i32 139, i32 127, ; 152..159
	i32 104, i32 46, i32 62, i32 4, i32 125, i32 5, i32 114, i32 143, ; 160..167
	i32 21, i32 79, i32 51, i32 53, i32 119, i32 116, i32 16, i32 108, ; 168..175
	i32 2, i32 126, i32 135, i32 34, i32 19, i32 14, i32 66, i32 34, ; 176..183
	i32 107, i32 32, i32 99, i32 124, i32 97, i32 64, i32 102, i32 7, ; 184..191
	i32 88, i32 92, i32 45, i32 56, i32 23, i32 140, i32 44, i32 134, ; 192..199
	i32 123, i32 80, i32 3, i32 40, i32 86, i32 36, i32 133, i32 39, ; 200..207
	i32 41, i32 93, i32 18, i32 40, i32 56, i32 48, i32 78, i32 22, ; 208..215
	i32 36, i32 140, i32 25, i32 121, i32 115, i32 20, i32 4, i32 88, ; 216..223
	i32 30, i32 13, i32 84, i32 38, i32 121, i32 73, i32 14, i32 100, ; 224..231
	i32 89, i32 103, i32 68, i32 6, i32 62, i32 94, i32 115, i32 15, ; 232..239
	i32 48, i32 128, i32 106, i32 61, i32 96, i32 61, i32 139, i32 0, ; 240..247
	i32 129, i32 27, i32 41, i32 0, i32 6, i32 37, i32 1, i32 70, ; 248..255
	i32 43, i32 117, i32 111, i32 85, i32 63, i32 93, i32 12, i32 72, ; 256..263
	i32 42, i32 32, i32 20, i32 33, i32 2, i32 17, i32 134, i32 58, ; 264..271
	i32 54, i32 142, i32 59, i32 138, i32 113, i32 95, i32 91, i32 39, ; 272..279
	i32 73, i32 9, i32 111, i32 138, i32 100, i32 8, i32 112, i32 46 ; 288..287
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
