; ModuleID = 'obj/Debug/android/marshal_methods.armeabi-v7a.ll'
source_filename = "obj/Debug/android/marshal_methods.armeabi-v7a.ll"
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
@assembly_image_cache_hashes = local_unnamed_addr constant [476 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 166
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 203
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 58
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 196
	i32 57967248, ; 4: Xamarin.Android.Support.VersionedParcelable.dll => 0x3748290 => 134
	i32 82002252, ; 5: Syncfusion.SfRangeSlider.XForms.Android.dll => 0x4e3414c => 86
	i32 99966887, ; 6: Xamarin.Firebase.Iid.dll => 0x5f55fa7 => 192
	i32 101534019, ; 7: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 180
	i32 113478513, ; 8: Syncfusion.SfRangeSlider.XForms.dll => 0x6c38b71 => 87
	i32 117431740, ; 9: System.Runtime.InteropServices => 0x6ffddbc => 232
	i32 120558881, ; 10: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 180
	i32 122350210, ; 11: System.Threading.Channels.dll => 0x74aea82 => 102
	i32 160529393, ; 12: Xamarin.Android.Arch.Core.Common => 0x9917bf1 => 107
	i32 164065134, ; 13: Unity.Abstractions => 0x9c76f6e => 105
	i32 165246403, ; 14: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 146
	i32 166922606, ; 15: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 117
	i32 182336117, ; 16: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 181
	i32 201930040, ; 17: Xamarin.Android.Arch.Core.Runtime => 0xc093538 => 108
	i32 209399409, ; 18: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 144
	i32 219130465, ; 19: Xamarin.Android.Support.v4 => 0xd0faa61 => 133
	i32 220171995, ; 20: System.Diagnostics.Debug => 0xd1f8edb => 13
	i32 221063263, ; 21: Microsoft.AspNetCore.Http.Connections.Client => 0xd2d285f => 38
	i32 229731493, ; 22: Huawei.Hms.NetworkGrs => 0xdb16ca5 => 30
	i32 230216969, ; 23: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 161
	i32 230752869, ; 24: Microsoft.CSharp.dll => 0xdc10265 => 46
	i32 231814094, ; 25: System.Globalization => 0xdd133ce => 227
	i32 232815796, ; 26: System.Web.Services => 0xde07cb4 => 223
	i32 261689757, ; 27: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 149
	i32 278686392, ; 28: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 165
	i32 280482487, ; 29: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 159
	i32 317030064, ; 30: Plugin.SharedTransitions.dll => 0x12e57eb0 => 64
	i32 318968648, ; 31: Xamarin.AndroidX.Activity.dll => 0x13031348 => 136
	i32 321597661, ; 32: System.Numerics => 0x132b30dd => 96
	i32 332531999, ; 33: Syncfusion.SfBusyIndicator.XForms.Android => 0x13d2091f => 79
	i32 342366114, ; 34: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 163
	i32 348048101, ; 35: Microsoft.AspNetCore.Http.Connections.Common.dll => 0x14becae5 => 39
	i32 385762202, ; 36: System.Memory.dll => 0x16fe439a => 94
	i32 389971796, ; 37: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 119
	i32 394611635, ; 38: Syncfusion.SfPdfViewer.XForms => 0x17854bb3 => 82
	i32 441335492, ; 39: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 148
	i32 442521989, ; 40: Xamarin.Essentials => 0x1a605985 => 190
	i32 442565967, ; 41: System.Collections => 0x1a61054f => 4
	i32 450948140, ; 42: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 158
	i32 458494020, ; 43: Microsoft.AspNetCore.SignalR.Common.dll => 0x1b541044 => 43
	i32 465846621, ; 44: mscorlib => 0x1bc4415d => 57
	i32 469710990, ; 45: System.dll => 0x1bff388e => 91
	i32 476646585, ; 46: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 159
	i32 486930444, ; 47: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 170
	i32 498788369, ; 48: System.ObjectModel => 0x1dbae811 => 236
	i32 501000162, ; 49: Prism.dll => 0x1ddca7e2 => 67
	i32 507185320, ; 50: NGraphics.Android.Custom.dll => 0x1e3b08a8 => 59
	i32 513247710, ; 51: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 52
	i32 514659665, ; 52: Xamarin.Android.Support.Compat => 0x1ead1551 => 117
	i32 516934521, ; 53: Huawei.Android.Hms.SecurityBase => 0x1ecfcb79 => 20
	i32 524864063, ; 54: Xamarin.Android.Support.Print => 0x1f48ca3f => 130
	i32 526420162, ; 55: System.Transactions.dll => 0x1f6088c2 => 218
	i32 535134469, ; 56: Syncfusion.SfBusyIndicator.Android => 0x1fe58105 => 78
	i32 536396994, ; 57: SVG.Forms.Plugin.Android.dll => 0x1ff8c4c2 => 72
	i32 539058512, ; 58: Microsoft.Extensions.Logging => 0x20216150 => 50
	i32 542030372, ; 59: Xamarin.GooglePlayServices.Stats => 0x204eba24 => 206
	i32 545304856, ; 60: System.Runtime.Extensions => 0x2080b118 => 6
	i32 548916678, ; 61: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 45
	i32 574378164, ; 62: XamSvg.Droid.dll => 0x223c50b4 => 214
	i32 577335427, ; 63: System.Security.Cryptography.Cng => 0x22697083 => 225
	i32 605376203, ; 64: System.IO.Compression.FileSystem => 0x24154ecb => 221
	i32 623623227, ; 65: HrApp => 0x252bbc3b => 18
	i32 627609679, ; 66: Xamarin.AndroidX.CustomView => 0x2568904f => 154
	i32 662205335, ; 67: System.Text.Encodings.Web.dll => 0x27787397 => 100
	i32 663517072, ; 68: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 186
	i32 665787137, ; 69: Huawei.Hms.Log.dll => 0x27af1b01 => 28
	i32 666292255, ; 70: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 141
	i32 672442732, ; 71: System.Collections.Concurrent => 0x2814a96c => 12
	i32 690569205, ; 72: System.Xml.Linq.dll => 0x29293ff5 => 104
	i32 692692150, ; 73: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 114
	i32 700284507, ; 74: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 208
	i32 702630279, ; 75: Huawei.Hms.NetworkGrs.dll => 0x29e14987 => 30
	i32 719061231, ; 76: Syncfusion.Core.XForms.dll => 0x2adc00ef => 75
	i32 767728125, ; 77: Syncfusion.SfPdfViewer.XForms.dll => 0x2dc299fd => 82
	i32 775507847, ; 78: System.IO.Compression => 0x2e394f87 => 220
	i32 775623772, ; 79: AiForms.Effects => 0x2e3b145c => 15
	i32 782533833, ; 80: Xamarin.Google.AutoValue.Annotations.dll => 0x2ea484c9 => 202
	i32 789151979, ; 81: Microsoft.Extensions.Options => 0x2f0980eb => 51
	i32 801787702, ; 82: Xamarin.Android.Support.Interpolator => 0x2fca4f36 => 126
	i32 809851609, ; 83: System.Drawing.Common.dll => 0x30455ad9 => 10
	i32 832711436, ; 84: Microsoft.AspNetCore.SignalR.Protocols.Json.dll => 0x31a22b0c => 44
	i32 843511501, ; 85: Xamarin.AndroidX.Print => 0x3246f6cd => 177
	i32 855944274, ; 86: NGraphics.Custom => 0x3304ac52 => 60
	i32 877678880, ; 87: System.Globalization.dll => 0x34505120 => 227
	i32 882883187, ; 88: Xamarin.Android.Support.v4.dll => 0x349fba73 => 133
	i32 910284651, ; 89: Syncfusion.SfRangeSlider.XForms => 0x3641d76b => 87
	i32 916714535, ; 90: Xamarin.Android.Support.Print.dll => 0x36a3f427 => 130
	i32 926997726, ; 91: Plugin.Multilingual.Abstractions => 0x3740dcde => 62
	i32 928116545, ; 92: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 203
	i32 934055265, ; 93: Huawei.Hms.Push.dll => 0x37ac8d61 => 32
	i32 955402788, ; 94: Newtonsoft.Json => 0x38f24a24 => 58
	i32 958213972, ; 95: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 129
	i32 967690846, ; 96: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 163
	i32 974778368, ; 97: FormsViewGroup.dll => 0x3a19f000 => 17
	i32 975236339, ; 98: System.Diagnostics.Tracing => 0x3a20ecf3 => 231
	i32 975874589, ; 99: System.Xml.XDocument => 0x3a2aaa1d => 228
	i32 987342438, ; 100: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0x3ad9a666 => 111
	i32 992768348, ; 101: System.Collections.dll => 0x3b2c715c => 4
	i32 1012816738, ; 102: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 179
	i32 1028951442, ; 103: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 47
	i32 1035644815, ; 104: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 140
	i32 1042160112, ; 105: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 199
	i32 1052210849, ; 106: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 167
	i32 1058641855, ; 107: Microsoft.AspNetCore.Http.Connections.Common => 0x3f1997bf => 39
	i32 1061503568, ; 108: Xamarin.Google.AutoValue.Annotations => 0x3f454250 => 202
	i32 1084122840, ; 109: Xamarin.Kotlin.StdLib => 0x409e66d8 => 210
	i32 1098167829, ; 110: Xamarin.Android.Arch.Lifecycle.ViewModel => 0x4174b615 => 113
	i32 1098259244, ; 111: System => 0x41761b2c => 91
	i32 1127295045, ; 112: Polly.dll => 0x43312845 => 66
	i32 1139625163, ; 113: SVG.Forms.Plugin.Abstractions.dll => 0x43ed4ccb => 71
	i32 1141947663, ; 114: Xamarin.Firebase.Measurement.Connector.dll => 0x4410bd0f => 194
	i32 1149099989, ; 115: Huawei.Android.Hms.SecuritySsl => 0x447ddfd5 => 22
	i32 1175144683, ; 116: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 184
	i32 1178241025, ; 117: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 174
	i32 1204270330, ; 118: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 141
	i32 1218518409, ; 119: Prism.Unity.Forms.dll => 0x48a11d89 => 69
	i32 1233093933, ; 120: Microsoft.AspNetCore.SignalR.Client.Core.dll => 0x497f852d => 41
	i32 1264538220, ; 121: Syncfusion.Compression.Portable => 0x4b5f526c => 73
	i32 1267360935, ; 122: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 185
	i32 1292763917, ; 123: Xamarin.Android.Support.CursorAdapter.dll => 0x4d0e030d => 121
	i32 1293217323, ; 124: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 156
	i32 1297413738, ; 125: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0x4d54f66a => 110
	i32 1309284514, ; 126: Plugin.FirebasePushNotification => 0x4e0a18a2 => 61
	i32 1324164729, ; 127: System.Linq => 0x4eed2679 => 230
	i32 1333047053, ; 128: Xamarin.Firebase.Common => 0x4f74af0d => 191
	i32 1345695187, ; 129: Syncfusion.SfRangeSlider.XForms.Android => 0x5035add3 => 86
	i32 1364015309, ; 130: System.IO => 0x514d38cd => 226
	i32 1365406463, ; 131: System.ServiceModel.Internals.dll => 0x516272ff => 224
	i32 1376866003, ; 132: Xamarin.AndroidX.SavedState => 0x52114ed3 => 179
	i32 1379779777, ; 133: System.Resources.ResourceManager => 0x523dc4c1 => 3
	i32 1380977605, ; 134: Huawei.Hms.Stats.dll => 0x52500bc5 => 33
	i32 1395857551, ; 135: Xamarin.AndroidX.Media.dll => 0x5333188f => 171
	i32 1406073936, ; 136: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 150
	i32 1411638395, ; 137: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 98
	i32 1414043276, ; 138: Microsoft.AspNetCore.Connections.Abstractions.dll => 0x5448968c => 37
	i32 1440999970, ; 139: Unity.Container => 0x55e3ea22 => 106
	i32 1445445088, ; 140: Xamarin.Android.Support.Fragment => 0x5627bde0 => 125
	i32 1449961411, ; 141: Huawei.Hms.Base => 0x566ca7c3 => 25
	i32 1457743152, ; 142: System.Runtime.Extensions.dll => 0x56e36530 => 6
	i32 1460219004, ; 143: Xamarin.Forms.Xaml => 0x57092c7c => 200
	i32 1460893475, ; 144: System.IdentityModel.Tokens.Jwt => 0x57137723 => 92
	i32 1462112819, ; 145: System.IO.Compression.dll => 0x57261233 => 220
	i32 1464784794, ; 146: Syncfusion.SfPdfViewer.XForms.Android => 0x574ed79a => 81
	i32 1469204771, ; 147: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 139
	i32 1470490898, ; 148: Microsoft.Extensions.Primitives => 0x57a5e912 => 52
	i32 1498168481, ; 149: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 53
	i32 1516315406, ; 150: Syncfusion.Core.XForms.Android.dll => 0x5a61230e => 74
	i32 1519760047, ; 151: Syncfusion.SfProgressBar.XForms.Android.dll => 0x5a95b2af => 83
	i32 1522103383, ; 152: Huawei.Hms.Device.dll => 0x5ab97457 => 26
	i32 1531040989, ; 153: Xamarin.Firebase.Iid.Interop.dll => 0x5b41d4dd => 193
	i32 1533253840, ; 154: Syncfusion.SfBusyIndicator.Android.dll => 0x5b6398d0 => 78
	i32 1543031311, ; 155: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 229
	i32 1550322496, ; 156: System.Reflection.Extensions.dll => 0x5c680b40 => 8
	i32 1566488712, ; 157: Syncfusion.SfBusyIndicator.XForms.dll => 0x5d5eb888 => 80
	i32 1574652163, ; 158: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 120
	i32 1582372066, ; 159: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 155
	i32 1582821230, ; 160: Huawei.Android.Hms.SecuritySsl.dll => 0x5e57ef6e => 22
	i32 1587447679, ; 161: Xamarin.Android.Arch.Core.Common.dll => 0x5e9e877f => 107
	i32 1592978981, ; 162: System.Runtime.Serialization.dll => 0x5ef2ee25 => 14
	i32 1612218441, ; 163: XamSvg.XamForms => 0x60188049 => 216
	i32 1615464666, ; 164: Huawei.Hms.Log => 0x604a08da => 28
	i32 1622152042, ; 165: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 169
	i32 1624863272, ; 166: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 188
	i32 1635860875, ; 167: Syncfusion.SfRangeSlider.Android => 0x6181418b => 85
	i32 1636350590, ; 168: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 153
	i32 1637556708, ; 169: Syncfusion.SfProgressBar.XForms.dll => 0x619b21e4 => 84
	i32 1639085333, ; 170: Huawei.Hms.Base.dll => 0x61b27515 => 25
	i32 1639515021, ; 171: System.Net.Http.dll => 0x61b9038d => 95
	i32 1639986890, ; 172: System.Text.RegularExpressions => 0x61c036ca => 229
	i32 1657153582, ; 173: System.Runtime => 0x62c6282e => 99
	i32 1658241508, ; 174: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 182
	i32 1658251792, ; 175: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 201
	i32 1663500400, ; 176: Huawei.Hmf.Tasks => 0x63270070 => 23
	i32 1670060433, ; 177: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 149
	i32 1698840827, ; 178: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 209
	i32 1701541528, ; 179: System.Diagnostics.Debug.dll => 0x656b7698 => 13
	i32 1706062090, ; 180: XamSvg.Shared => 0x65b0710a => 215
	i32 1726116996, ; 181: System.Reflection.dll => 0x66e27484 => 7
	i32 1729485958, ; 182: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 145
	i32 1739193536, ; 183: NGraphics.Android.Custom => 0x67a9fcc0 => 59
	i32 1740319209, ; 184: Huawei.Hms.Hatool => 0x67bb29e9 => 27
	i32 1746115085, ; 185: System.IO.Pipelines.dll => 0x68139a0d => 93
	i32 1765942094, ; 186: System.Reflection.Extensions => 0x6942234e => 8
	i32 1766324549, ; 187: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 181
	i32 1770582343, ; 188: Microsoft.Extensions.Logging.dll => 0x6988f147 => 50
	i32 1776026572, ; 189: System.Core.dll => 0x69dc03cc => 89
	i32 1788241197, ; 190: Xamarin.AndroidX.Fragment => 0x6a96652d => 158
	i32 1796167890, ; 191: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 45
	i32 1808609942, ; 192: Xamarin.AndroidX.Loader => 0x6bcd3296 => 169
	i32 1813058853, ; 193: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 210
	i32 1813201214, ; 194: Xamarin.Google.Android.Material => 0x6c13413e => 201
	i32 1818569960, ; 195: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 175
	i32 1819327070, ; 196: Microsoft.AspNetCore.Http.Features.dll => 0x6c70ba5e => 40
	i32 1828688058, ; 197: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 49
	i32 1835480782, ; 198: XamSvg.Droid => 0x6d6736ce => 214
	i32 1849271627, ; 199: Prism.Forms.dll => 0x6e39a54b => 68
	i32 1866717392, ; 200: Xamarin.Android.Support.Interpolator.dll => 0x6f43d8d0 => 126
	i32 1867746548, ; 201: Xamarin.Essentials.dll => 0x6f538cf4 => 190
	i32 1878053835, ; 202: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 200
	i32 1885316902, ; 203: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 142
	i32 1900610850, ; 204: System.Resources.ResourceManager.dll => 0x71490522 => 3
	i32 1905322901, ; 205: Huawei.Hms.Opendevice.dll => 0x7190eb95 => 31
	i32 1908813208, ; 206: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 205
	i32 1916660109, ; 207: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x723de98d => 113
	i32 1917312288, ; 208: AiForms.Effects.Droid.dll => 0x7247dd20 => 16
	i32 1919157823, ; 209: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 172
	i32 1933215285, ; 210: Xamarin.Firebase.Messaging.dll => 0x733a8635 => 195
	i32 1945717188, ; 211: Microsoft.AspNetCore.SignalR.Client.Core => 0x73f949c4 => 41
	i32 1967334205, ; 212: Microsoft.AspNetCore.SignalR.Common => 0x7543233d => 43
	i32 1974606741, ; 213: NGraphics.Custom.dll => 0x75b21b95 => 60
	i32 1983156543, ; 214: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 209
	i32 1986222447, ; 215: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 55
	i32 2011961780, ; 216: System.Buffers.dll => 0x77ec19b4 => 88
	i32 2019465201, ; 217: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 167
	i32 2037417872, ; 218: Xamarin.Android.Support.ViewPager => 0x79708790 => 135
	i32 2044222327, ; 219: Xamarin.Android.Support.Loader => 0x79d85b77 => 127
	i32 2055257422, ; 220: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 164
	i32 2059619953, ; 221: Plugin.SharedTransitions => 0x7ac34e71 => 64
	i32 2065833063, ; 222: Unity.Container.dll => 0x7b221c67 => 106
	i32 2066202781, ; 223: Prism => 0x7b27c09d => 67
	i32 2066297753, ; 224: Huawei.Hms.Availableupdate.dll => 0x7b293399 => 24
	i32 2077425357, ; 225: Huawei.Hms.Stats => 0x7bd2fecd => 33
	i32 2079627543, ; 226: Plugin.Multilingual.dll => 0x7bf49917 => 63
	i32 2079903147, ; 227: System.Runtime.dll => 0x7bf8cdab => 99
	i32 2090596640, ; 228: System.Numerics.Vectors => 0x7c9bf920 => 97
	i32 2097448633, ; 229: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 160
	i32 2113902067, ; 230: Xamarin.Forms.PancakeView.dll => 0x7dff95f3 => 197
	i32 2126786730, ; 231: Xamarin.Forms.Platform.Android => 0x7ec430aa => 198
	i32 2129483829, ; 232: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 204
	i32 2139458754, ; 233: Xamarin.Android.Support.DrawerLayout => 0x7f858cc2 => 124
	i32 2147356122, ; 234: Huawei.Android.Hms.SecurityBase.dll => 0x7ffe0dda => 20
	i32 2166116741, ; 235: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 120
	i32 2181898931, ; 236: Microsoft.Extensions.Options.dll => 0x820d22b3 => 51
	i32 2192057212, ; 237: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 49
	i32 2193016926, ; 238: System.ObjectModel.dll => 0x82b6c85e => 236
	i32 2196165013, ; 239: Xamarin.Android.Support.VersionedParcelable => 0x82e6d195 => 134
	i32 2201231467, ; 240: System.Net.Http => 0x8334206b => 95
	i32 2217644978, ; 241: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 184
	i32 2223043141, ; 242: Huawei.Hmf.Tasks.dll => 0x8480f245 => 23
	i32 2244775296, ; 243: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 170
	i32 2256548716, ; 244: Xamarin.AndroidX.MultiDex => 0x8680336c => 172
	i32 2261435625, ; 245: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 162
	i32 2279755925, ; 246: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 178
	i32 2315684594, ; 247: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 137
	i32 2319144366, ; 248: Microsoft.AspNetCore.SignalR.Client => 0x8a3b55ae => 42
	i32 2330457430, ; 249: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 119
	i32 2330986192, ; 250: Xamarin.Android.Support.SlidingPaneLayout.dll => 0x8af006d0 => 131
	i32 2343171156, ; 251: Syncfusion.Core.XForms => 0x8ba9f454 => 75
	i32 2354730003, ; 252: Syncfusion.Licensing => 0x8c5a5413 => 76
	i32 2369706906, ; 253: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 54
	i32 2373047941, ; 254: XamForms.Controls.Calendar.Droid => 0x8d71d685 => 212
	i32 2373288475, ; 255: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 125
	i32 2397082276, ; 256: Xamarin.Forms.PancakeView => 0x8ee092a4 => 197
	i32 2409053734, ; 257: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 176
	i32 2440966767, ; 258: Xamarin.Android.Support.Loader.dll => 0x917e326f => 127
	i32 2452282595, ; 259: Syncfusion.SfPdfViewer.XForms.Android.dll => 0x922adce3 => 81
	i32 2454642406, ; 260: System.Text.Encoding.dll => 0x924edee6 => 9
	i32 2465532216, ; 261: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 148
	i32 2467049111, ; 262: Huawei.Agconnect.AgconnectCore => 0x930c2e97 => 19
	i32 2471215200, ; 263: ImageCircle.Forms.Plugin => 0x934bc060 => 35
	i32 2471841756, ; 264: netstandard.dll => 0x93554fdc => 2
	i32 2475788418, ; 265: Java.Interop.dll => 0x93918882 => 36
	i32 2483661569, ; 266: Xamarin.Firebase.Measurement.Connector => 0x9409ab01 => 194
	i32 2483742551, ; 267: Xamarin.Firebase.Messaging => 0x940ae757 => 195
	i32 2487632829, ; 268: Xamarin.Android.Support.DocumentFile => 0x944643bd => 123
	i32 2490993605, ; 269: System.AppContext.dll => 0x94798bc5 => 233
	i32 2501346920, ; 270: System.Data.DataSetExtensions => 0x95178668 => 219
	i32 2505896520, ; 271: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 166
	i32 2562349572, ; 272: Microsoft.CSharp => 0x98ba5a04 => 46
	i32 2570120770, ; 273: System.Text.Encodings.Web => 0x9930ee42 => 100
	i32 2578279760, ; 274: XamSvg.XamForms.dll => 0x99ad6d50 => 216
	i32 2581819634, ; 275: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 185
	i32 2620871830, ; 276: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 153
	i32 2624644809, ; 277: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 157
	i32 2633051222, ; 278: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 165
	i32 2640290731, ; 279: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 54
	i32 2644307787, ; 280: Huawei.Hms.Availableupdate => 0x9d9cef4b => 24
	i32 2664396074, ; 281: System.Xml.XDocument.dll => 0x9ecf752a => 228
	i32 2693849962, ; 282: System.IO.dll => 0xa090e36a => 226
	i32 2698266930, ; 283: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa0d44932 => 111
	i32 2701096212, ; 284: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 182
	i32 2715334215, ; 285: System.Threading.Tasks.dll => 0xa1d8b647 => 237
	i32 2719963679, ; 286: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 225
	i32 2727552820, ; 287: Huawei.Hms.Device => 0xa2932734 => 26
	i32 2732626843, ; 288: Xamarin.AndroidX.Activity => 0xa2e0939b => 136
	i32 2735172069, ; 289: System.Threading.Channels => 0xa30769e5 => 102
	i32 2737747696, ; 290: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 139
	i32 2751899777, ; 291: Xamarin.Android.Support.Collections => 0xa406a881 => 116
	i32 2763696748, ; 292: Syncfusion.SfRangeSlider.Android.dll => 0xa4baaa6c => 85
	i32 2765824710, ; 293: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 11
	i32 2766581644, ; 294: Xamarin.Forms.Core => 0xa4e6af8c => 196
	i32 2770495804, ; 295: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 208
	i32 2778768386, ; 296: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 187
	i32 2788639665, ; 297: Xamarin.Android.Support.LocalBroadcastManager => 0xa63743b1 => 128
	i32 2788775637, ; 298: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0xa63956d5 => 132
	i32 2810250172, ; 299: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 150
	i32 2819470561, ; 300: System.Xml.dll => 0xa80db4e1 => 103
	i32 2847418871, ; 301: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 204
	i32 2850549256, ; 302: Microsoft.AspNetCore.Http.Features => 0xa9e7ee08 => 40
	i32 2853208004, ; 303: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 187
	i32 2854891590, ; 304: Syncfusion.SfProgressBar.XForms => 0xaa2a3046 => 84
	i32 2855708567, ; 305: Xamarin.AndroidX.Transition => 0xaa36a797 => 183
	i32 2868557005, ; 306: Syncfusion.Licensing.dll => 0xaafab4cd => 76
	i32 2870995654, ; 307: Xamarin.Firebase.Iid => 0xab1feac6 => 192
	i32 2874148507, ; 308: Syncfusion.Core.XForms.Android => 0xab50069b => 74
	i32 2875347124, ; 309: Microsoft.AspNetCore.Http.Connections.Client.dll => 0xab6250b4 => 38
	i32 2876493027, ; 310: Xamarin.Android.Support.SwipeRefreshLayout => 0xab73cce3 => 132
	i32 2886109683, ; 311: Syncfusion.SfBusyIndicator.XForms.Android.dll => 0xac0689f3 => 79
	i32 2893257763, ; 312: Xamarin.Android.Arch.Core.Runtime.dll => 0xac739c23 => 108
	i32 2901442782, ; 313: System.Reflection => 0xacf080de => 7
	i32 2903344695, ; 314: System.ComponentModel.Composition => 0xad0d8637 => 222
	i32 2905242038, ; 315: mscorlib.dll => 0xad2a79b6 => 57
	i32 2914202368, ; 316: Xamarin.Firebase.Iid.Interop => 0xadb33300 => 193
	i32 2916838712, ; 317: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 188
	i32 2917517763, ; 318: Plugin.XamarinFormsSaveOpenPDFPackage.dll => 0xade5c9c3 => 65
	i32 2919462931, ; 319: System.Numerics.Vectors.dll => 0xae037813 => 97
	i32 2921128767, ; 320: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 138
	i32 2921692953, ; 321: Xamarin.Android.Support.CustomView.dll => 0xae257f19 => 122
	i32 2923486322, ; 322: Prism.Unity.Forms => 0xae40dc72 => 69
	i32 2934963324, ; 323: HrApp.dll => 0xaeeffc7c => 18
	i32 2965194746, ; 324: Huawei.Hms.NetworkCommon => 0xb0bd47fa => 29
	i32 2978675010, ; 325: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 156
	i32 3020614608, ; 326: XamSvg.Abstractions => 0xb40aebd0 => 213
	i32 3024354802, ; 327: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 161
	i32 3044182254, ; 328: FormsViewGroup => 0xb57288ee => 17
	i32 3056250942, ; 329: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0xb62ab03e => 115
	i32 3057625584, ; 330: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 173
	i32 3058099980, ; 331: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 207
	i32 3068715062, ; 332: Xamarin.Android.Arch.Lifecycle.Common => 0xb6e8e036 => 109
	i32 3071899978, ; 333: Xamarin.Firebase.Common.dll => 0xb719794a => 191
	i32 3075834255, ; 334: System.Threading.Tasks => 0xb755818f => 237
	i32 3084678329, ; 335: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 55
	i32 3092211740, ; 336: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 129
	i32 3111772706, ; 337: System.Runtime.Serialization => 0xb979e222 => 14
	i32 3124832203, ; 338: System.Threading.Tasks.Extensions => 0xba4127cb => 235
	i32 3147165239, ; 339: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 231
	i32 3196832649, ; 340: Plugin.Multilingual => 0xbe8bcb89 => 63
	i32 3204380047, ; 341: System.Data.dll => 0xbefef58f => 217
	i32 3204912593, ; 342: Xamarin.Android.Support.AsyncLayoutInflater => 0xbf0715d1 => 115
	i32 3211777861, ; 343: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 155
	i32 3220365878, ; 344: System.Threading => 0xbff2e236 => 5
	i32 3230466174, ; 345: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 205
	i32 3233339011, ; 346: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xc0b8d683 => 110
	i32 3247949154, ; 347: Mono.Security => 0xc197c562 => 234
	i32 3248508112, ; 348: HrApp.Android.dll => 0xc1a04cd0 => 1
	i32 3249260365, ; 349: RestSharp.dll => 0xc1abc74d => 70
	i32 3258312781, ; 350: Xamarin.AndroidX.CardView => 0xc235e84d => 145
	i32 3265893370, ; 351: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 235
	i32 3267021929, ; 352: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 143
	i32 3273112673, ; 353: Huawei.Hms.NetworkCommon.dll => 0xc317bc61 => 29
	i32 3288844784, ; 354: Huawei.Android.Hms.SecurityEncrypt => 0xc407c9f0 => 21
	i32 3296380511, ; 355: Xamarin.Android.Support.Collections.dll => 0xc47ac65f => 116
	i32 3299363146, ; 356: System.Text.Encoding => 0xc4a8494a => 9
	i32 3312457198, ; 357: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 53
	i32 3317135071, ; 358: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 154
	i32 3317144872, ; 359: System.Data => 0xc5b79d28 => 217
	i32 3321585405, ; 360: Xamarin.Android.Support.DocumentFile.dll => 0xc5fb5efd => 123
	i32 3321792619, ; 361: XamSvg.Abstractions.dll => 0xc5fe886b => 213
	i32 3331531814, ; 362: Xamarin.GooglePlayServices.Stats.dll => 0xc6932426 => 206
	i32 3340431453, ; 363: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 142
	i32 3346324047, ; 364: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 174
	i32 3352662376, ; 365: Xamarin.Android.Support.CoordinaterLayout => 0xc7d59168 => 118
	i32 3353484488, ; 366: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 160
	i32 3353544232, ; 367: Xamarin.CommunityToolkit.dll => 0xc7e30628 => 189
	i32 3357663996, ; 368: Xamarin.Android.Support.CursorAdapter => 0xc821e2fc => 121
	i32 3358260929, ; 369: System.Text.Json => 0xc82afec1 => 101
	i32 3362522851, ; 370: Xamarin.AndroidX.Core => 0xc86c06e3 => 152
	i32 3366347497, ; 371: Java.Interop => 0xc8a662e9 => 36
	i32 3374517072, ; 372: Plugin.XamarinFormsSaveOpenPDFPackage => 0xc9230b50 => 65
	i32 3374999561, ; 373: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 178
	i32 3395150330, ; 374: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 98
	i32 3401559547, ; 375: Plugin.FirebasePushNotification.dll => 0xcabfadfb => 61
	i32 3404865022, ; 376: System.ServiceModel.Internals => 0xcaf21dfe => 224
	i32 3407215217, ; 377: Xamarin.CommunityToolkit => 0xcb15fa71 => 189
	i32 3428513518, ; 378: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 48
	i32 3429136800, ; 379: System.Xml => 0xcc6479a0 => 103
	i32 3430777524, ; 380: netstandard => 0xcc7d82b4 => 2
	i32 3433996769, ; 381: Syncfusion.Pdf.Portable.dll => 0xccaea1e1 => 77
	i32 3439690031, ; 382: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 114
	i32 3441283291, ; 383: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 157
	i32 3448896322, ; 384: Polly => 0xcd91fb42 => 66
	i32 3460255358, ; 385: Syncfusion.SfBusyIndicator.XForms => 0xce3f4e7e => 80
	i32 3466904072, ; 386: Microsoft.AspNetCore.SignalR.Client.dll => 0xcea4c208 => 42
	i32 3476120550, ; 387: Mono.Android => 0xcf3163e6 => 56
	i32 3483112796, ; 388: ImageCircle.Forms.Plugin.dll => 0xcf9c155c => 35
	i32 3484999123, ; 389: SVG.Forms.Plugin.Abstractions => 0xcfb8ddd3 => 71
	i32 3485117614, ; 390: System.Text.Json.dll => 0xcfbaacae => 101
	i32 3486566296, ; 391: System.Transactions => 0xcfd0c798 => 218
	i32 3493954962, ; 392: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 147
	i32 3501239056, ; 393: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 143
	i32 3509114376, ; 394: System.Xml.Linq => 0xd128d608 => 104
	i32 3534510610, ; 395: Huawei.Android.Hms.SecurityEncrypt.dll => 0xd2ac5a12 => 21
	i32 3536029504, ; 396: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 198
	i32 3544322670, ; 397: Syncfusion.SfProgressBar.XForms.Android => 0xd342126e => 83
	i32 3547625832, ; 398: Xamarin.Android.Support.SlidingPaneLayout => 0xd3747968 => 131
	i32 3549863983, ; 399: Huawei.Hms.Ui.dll => 0xd396a02f => 34
	i32 3551972787, ; 400: Syncfusion.Compression.Portable.dll => 0xd3b6cdb3 => 73
	i32 3567349600, ; 401: System.ComponentModel.Composition.dll => 0xd4a16f60 => 222
	i32 3579529003, ; 402: Huawei.Hms.Ui => 0xd55b472b => 34
	i32 3586971312, ; 403: XamForms.Controls.Calendar.Droid.dll => 0xd5ccd6b0 => 212
	i32 3596054127, ; 404: HrApp.resources.dll => 0xd6576e6f => 0
	i32 3608519521, ; 405: System.Linq.dll => 0xd715a361 => 230
	i32 3618140916, ; 406: Xamarin.AndroidX.Preference => 0xd7a872f4 => 176
	i32 3627220390, ; 407: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 177
	i32 3632359727, ; 408: Xamarin.Forms.Platform => 0xd881692f => 199
	i32 3633644679, ; 409: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 138
	i32 3641597786, ; 410: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 164
	i32 3644908295, ; 411: HrApp.Android => 0xd940e307 => 1
	i32 3664423555, ; 412: Xamarin.Android.Support.ViewPager.dll => 0xda6aaa83 => 135
	i32 3669463323, ; 413: HrApp.resources => 0xdab7911b => 0
	i32 3672681054, ; 414: Mono.Android.dll => 0xdae8aa5e => 56
	i32 3676310014, ; 415: System.Web.Services.dll => 0xdb2009fe => 223
	i32 3681174138, ; 416: Xamarin.Android.Arch.Lifecycle.Common.dll => 0xdb6a427a => 109
	i32 3682565725, ; 417: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 144
	i32 3684561358, ; 418: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 147
	i32 3689375977, ; 419: System.Drawing.Common => 0xdbe768e9 => 10
	i32 3691870036, ; 420: Microsoft.AspNetCore.SignalR.Protocols.Json => 0xdc0d7754 => 44
	i32 3706696989, ; 421: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 151
	i32 3714038699, ; 422: Xamarin.Android.Support.LocalBroadcastManager.dll => 0xdd5fbbab => 128
	i32 3716573645, ; 423: AiForms.Effects.Droid => 0xdd8669cd => 16
	i32 3718780102, ; 424: Xamarin.AndroidX.Annotation => 0xdda814c6 => 137
	i32 3724971120, ; 425: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 173
	i32 3733882439, ; 426: Unity.Abstractions.dll => 0xde8e8647 => 105
	i32 3748608112, ; 427: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 90
	i32 3754700086, ; 428: Plugin.Multilingual.Abstractions.dll => 0xdfcc2d36 => 62
	i32 3758932259, ; 429: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 162
	i32 3776062606, ; 430: Xamarin.Android.Support.DrawerLayout.dll => 0xe112248e => 124
	i32 3786282454, ; 431: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 146
	i32 3787005001, ; 432: Microsoft.AspNetCore.Connections.Abstractions => 0xe1b91c49 => 37
	i32 3816437471, ; 433: RestSharp => 0xe37a36df => 70
	i32 3822602673, ; 434: Xamarin.AndroidX.Media => 0xe3d849b1 => 171
	i32 3829621856, ; 435: System.Numerics.dll => 0xe4436460 => 96
	i32 3832731800, ; 436: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe472d898 => 118
	i32 3841636137, ; 437: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 47
	i32 3849253459, ; 438: System.Runtime.InteropServices.dll => 0xe56ef253 => 232
	i32 3862817207, ; 439: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0xe63de9b7 => 112
	i32 3871651808, ; 440: AiForms.Effects.dll => 0xe6c4b7e0 => 15
	i32 3874897629, ; 441: Xamarin.Android.Arch.Lifecycle.Runtime => 0xe6f63edd => 112
	i32 3885922214, ; 442: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 183
	i32 3896106733, ; 443: System.Collections.Concurrent.dll => 0xe839deed => 12
	i32 3896760992, ; 444: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 152
	i32 3920810846, ; 445: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 221
	i32 3921031405, ; 446: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 186
	i32 3931092270, ; 447: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 175
	i32 3945713374, ; 448: System.Data.DataSetExtensions.dll => 0xeb2ecede => 219
	i32 3953953790, ; 449: System.Text.Encoding.CodePages => 0xebac8bfe => 11
	i32 3955647286, ; 450: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 140
	i32 3970018735, ; 451: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 207
	i32 3975321146, ; 452: Huawei.Hms.Opendevice => 0xecf2963a => 31
	i32 3979229314, ; 453: Huawei.Hms.Hatool.dll => 0xed2e3882 => 27
	i32 4002401680, ; 454: XamSvg.Shared.dll => 0xee8fcd90 => 215
	i32 4004187228, ; 455: Huawei.Hms.Push => 0xeeab0c5c => 32
	i32 4014908255, ; 456: XamForms.Controls.Calendar => 0xef4ea35f => 211
	i32 4023392905, ; 457: System.IO.Pipelines => 0xefd01a89 => 93
	i32 4025784931, ; 458: System.Memory => 0xeff49a63 => 94
	i32 4050386365, ; 459: SVG.Forms.Plugin.Android => 0xf16bfdbd => 72
	i32 4063435586, ; 460: Xamarin.Android.Support.CustomView => 0xf2331b42 => 122
	i32 4073602200, ; 461: System.Threading.dll => 0xf2ce3c98 => 5
	i32 4085261167, ; 462: Prism.Forms => 0xf380236f => 68
	i32 4105002889, ; 463: Mono.Security.dll => 0xf4ad5f89 => 234
	i32 4126470640, ; 464: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 48
	i32 4130442656, ; 465: System.AppContext => 0xf6318da0 => 233
	i32 4151237749, ; 466: System.Core => 0xf76edc75 => 89
	i32 4182413190, ; 467: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 168
	i32 4213026141, ; 468: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 90
	i32 4220811361, ; 469: XamForms.Controls.Calendar.dll => 0xfb947861 => 211
	i32 4221941870, ; 470: Syncfusion.Pdf.Portable => 0xfba5b86e => 77
	i32 4256097574, ; 471: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 151
	i32 4260525087, ; 472: System.Buffers => 0xfdf2741f => 88
	i32 4263231520, ; 473: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 92
	i32 4292120959, ; 474: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 168
	i32 4293620108 ; 475: Huawei.Agconnect.AgconnectCore.dll => 0xffeb718c => 19
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [476 x i32] [
	i32 166, i32 203, i32 58, i32 196, i32 134, i32 86, i32 192, i32 180, ; 0..7
	i32 87, i32 232, i32 180, i32 102, i32 107, i32 105, i32 146, i32 117, ; 8..15
	i32 181, i32 108, i32 144, i32 133, i32 13, i32 38, i32 30, i32 161, ; 16..23
	i32 46, i32 227, i32 223, i32 149, i32 165, i32 159, i32 64, i32 136, ; 24..31
	i32 96, i32 79, i32 163, i32 39, i32 94, i32 119, i32 82, i32 148, ; 32..39
	i32 190, i32 4, i32 158, i32 43, i32 57, i32 91, i32 159, i32 170, ; 40..47
	i32 236, i32 67, i32 59, i32 52, i32 117, i32 20, i32 130, i32 218, ; 48..55
	i32 78, i32 72, i32 50, i32 206, i32 6, i32 45, i32 214, i32 225, ; 56..63
	i32 221, i32 18, i32 154, i32 100, i32 186, i32 28, i32 141, i32 12, ; 64..71
	i32 104, i32 114, i32 208, i32 30, i32 75, i32 82, i32 220, i32 15, ; 72..79
	i32 202, i32 51, i32 126, i32 10, i32 44, i32 177, i32 60, i32 227, ; 80..87
	i32 133, i32 87, i32 130, i32 62, i32 203, i32 32, i32 58, i32 129, ; 88..95
	i32 163, i32 17, i32 231, i32 228, i32 111, i32 4, i32 179, i32 47, ; 96..103
	i32 140, i32 199, i32 167, i32 39, i32 202, i32 210, i32 113, i32 91, ; 104..111
	i32 66, i32 71, i32 194, i32 22, i32 184, i32 174, i32 141, i32 69, ; 112..119
	i32 41, i32 73, i32 185, i32 121, i32 156, i32 110, i32 61, i32 230, ; 120..127
	i32 191, i32 86, i32 226, i32 224, i32 179, i32 3, i32 33, i32 171, ; 128..135
	i32 150, i32 98, i32 37, i32 106, i32 125, i32 25, i32 6, i32 200, ; 136..143
	i32 92, i32 220, i32 81, i32 139, i32 52, i32 53, i32 74, i32 83, ; 144..151
	i32 26, i32 193, i32 78, i32 229, i32 8, i32 80, i32 120, i32 155, ; 152..159
	i32 22, i32 107, i32 14, i32 216, i32 28, i32 169, i32 188, i32 85, ; 160..167
	i32 153, i32 84, i32 25, i32 95, i32 229, i32 99, i32 182, i32 201, ; 168..175
	i32 23, i32 149, i32 209, i32 13, i32 215, i32 7, i32 145, i32 59, ; 176..183
	i32 27, i32 93, i32 8, i32 181, i32 50, i32 89, i32 158, i32 45, ; 184..191
	i32 169, i32 210, i32 201, i32 175, i32 40, i32 49, i32 214, i32 68, ; 192..199
	i32 126, i32 190, i32 200, i32 142, i32 3, i32 31, i32 205, i32 113, ; 200..207
	i32 16, i32 172, i32 195, i32 41, i32 43, i32 60, i32 209, i32 55, ; 208..215
	i32 88, i32 167, i32 135, i32 127, i32 164, i32 64, i32 106, i32 67, ; 216..223
	i32 24, i32 33, i32 63, i32 99, i32 97, i32 160, i32 197, i32 198, ; 224..231
	i32 204, i32 124, i32 20, i32 120, i32 51, i32 49, i32 236, i32 134, ; 232..239
	i32 95, i32 184, i32 23, i32 170, i32 172, i32 162, i32 178, i32 137, ; 240..247
	i32 42, i32 119, i32 131, i32 75, i32 76, i32 54, i32 212, i32 125, ; 248..255
	i32 197, i32 176, i32 127, i32 81, i32 9, i32 148, i32 19, i32 35, ; 256..263
	i32 2, i32 36, i32 194, i32 195, i32 123, i32 233, i32 219, i32 166, ; 264..271
	i32 46, i32 100, i32 216, i32 185, i32 153, i32 157, i32 165, i32 54, ; 272..279
	i32 24, i32 228, i32 226, i32 111, i32 182, i32 237, i32 225, i32 26, ; 280..287
	i32 136, i32 102, i32 139, i32 116, i32 85, i32 11, i32 196, i32 208, ; 288..295
	i32 187, i32 128, i32 132, i32 150, i32 103, i32 204, i32 40, i32 187, ; 296..303
	i32 84, i32 183, i32 76, i32 192, i32 74, i32 38, i32 132, i32 79, ; 304..311
	i32 108, i32 7, i32 222, i32 57, i32 193, i32 188, i32 65, i32 97, ; 312..319
	i32 138, i32 122, i32 69, i32 18, i32 29, i32 156, i32 213, i32 161, ; 320..327
	i32 17, i32 115, i32 173, i32 207, i32 109, i32 191, i32 237, i32 55, ; 328..335
	i32 129, i32 14, i32 235, i32 231, i32 63, i32 217, i32 115, i32 155, ; 336..343
	i32 5, i32 205, i32 110, i32 234, i32 1, i32 70, i32 145, i32 235, ; 344..351
	i32 143, i32 29, i32 21, i32 116, i32 9, i32 53, i32 154, i32 217, ; 352..359
	i32 123, i32 213, i32 206, i32 142, i32 174, i32 118, i32 160, i32 189, ; 360..367
	i32 121, i32 101, i32 152, i32 36, i32 65, i32 178, i32 98, i32 61, ; 368..375
	i32 224, i32 189, i32 48, i32 103, i32 2, i32 77, i32 114, i32 157, ; 376..383
	i32 66, i32 80, i32 42, i32 56, i32 35, i32 71, i32 101, i32 218, ; 384..391
	i32 147, i32 143, i32 104, i32 21, i32 198, i32 83, i32 131, i32 34, ; 392..399
	i32 73, i32 222, i32 34, i32 212, i32 0, i32 230, i32 176, i32 177, ; 400..407
	i32 199, i32 138, i32 164, i32 1, i32 135, i32 0, i32 56, i32 223, ; 408..415
	i32 109, i32 144, i32 147, i32 10, i32 44, i32 151, i32 128, i32 16, ; 416..423
	i32 137, i32 173, i32 105, i32 90, i32 62, i32 162, i32 124, i32 146, ; 424..431
	i32 37, i32 70, i32 171, i32 96, i32 118, i32 47, i32 232, i32 112, ; 432..439
	i32 15, i32 112, i32 183, i32 12, i32 152, i32 221, i32 186, i32 175, ; 440..447
	i32 219, i32 11, i32 140, i32 207, i32 31, i32 27, i32 215, i32 32, ; 448..455
	i32 211, i32 93, i32 94, i32 72, i32 122, i32 5, i32 68, i32 234, ; 456..463
	i32 48, i32 233, i32 89, i32 168, i32 90, i32 211, i32 77, i32 151, ; 464..471
	i32 88, i32 92, i32 168, i32 19 ; 472..475
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
