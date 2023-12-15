; ModuleID = 'obj/Debug/android/marshal_methods.arm64-v8a.ll'
source_filename = "obj/Debug/android/marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [476 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 157
	i64 98382396393917666, ; 1: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 52
	i64 120698629574877762, ; 2: Mono.Android => 0x1accec39cafe242 => 56
	i64 184249734353293910, ; 3: Unity.Container.dll => 0x28e96283e169256 => 106
	i64 210515253464952879, ; 4: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 146
	i64 232391251801502327, ; 5: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 179
	i64 295915112840604065, ; 6: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 180
	i64 316157742385208084, ; 7: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 151
	i64 347331204332682223, ; 8: ImageCircle.Forms.Plugin => 0x4d1f7e3dda87bef => 35
	i64 590536689428908136, ; 9: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x83201fd803ec868 => 113
	i64 602466766465879987, ; 10: HrApp.Android => 0x85c6455042d4fb3 => 1
	i64 634308326490598313, ; 11: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 166
	i64 687654259221141486, ; 12: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 204
	i64 702024105029695270, ; 13: System.Drawing.Common => 0x9be17343c0e7726 => 10
	i64 720058930071658100, ; 14: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 160
	i64 761608270782653079, ; 15: Syncfusion.SfBusyIndicator.XForms.Android => 0xa91c6afe5ffe297 => 79
	i64 816102801403336439, ; 16: Xamarin.Android.Support.Collections => 0xb53612c89d8d6f7 => 116
	i64 846634227898301275, ; 17: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0xbbfd9583890bb5b => 110
	i64 872800313462103108, ; 18: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 156
	i64 930393596299815015, ; 19: Syncfusion.SfRangeSlider.XForms.Android => 0xce96c0be0bfa867 => 86
	i64 940822596282819491, ; 20: System.Transactions => 0xd0e792aa81923a3 => 218
	i64 994940342227176444, ; 21: Huawei.Hms.Push.dll => 0xdcebcf847280bfc => 32
	i64 996343623809489702, ; 22: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 199
	i64 1000557547492888992, ; 23: Mono.Security.dll => 0xde2b1c9cba651a0 => 234
	i64 1120440138749646132, ; 24: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 201
	i64 1252782872435405224, ; 25: Syncfusion.SfPdfViewer.XForms.Android => 0x1162c7628c34b1a8 => 81
	i64 1315114680217950157, ; 26: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 141
	i64 1342439039765371018, ; 27: Xamarin.Android.Support.Fragment => 0x12a14d31b1d4d88a => 125
	i64 1425944114962822056, ; 28: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 14
	i64 1490981186906623721, ; 29: Xamarin.Android.Support.VersionedParcelable => 0x14b1077d6c5c0ee9 => 134
	i64 1491290866305144020, ; 30: Xamarin.Google.AutoValue.Annotations.dll => 0x14b2212446e714d4 => 202
	i64 1624659445732251991, ; 31: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 139
	i64 1628611045998245443, ; 32: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 168
	i64 1636321030536304333, ; 33: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 161
	i64 1731380447121279447, ; 34: Newtonsoft.Json => 0x18071957e9b889d7 => 58
	i64 1743969030606105336, ; 35: System.Memory.dll => 0x1833d297e88f2af8 => 94
	i64 1795316252682057001, ; 36: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 140
	i64 1797009951756623539, ; 37: AiForms.Effects.Droid.dll => 0x18f04307b84b9eb3 => 16
	i64 1836611346387731153, ; 38: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 179
	i64 1865037103900624886, ; 39: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 45
	i64 1875917498431009007, ; 40: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 137
	i64 1938067011858688285, ; 41: Xamarin.Android.Support.v4.dll => 0x1ae565add0bd691d => 133
	i64 1981742497975770890, ; 42: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 167
	i64 1986553961460820075, ; 43: Xamarin.CommunityToolkit => 0x1b91a84d8004686b => 189
	i64 2040001226662520565, ; 44: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 235
	i64 2061151250911352171, ; 45: Huawei.Hms.Log => 0x1c9aae246aec556b => 28
	i64 2076847052340733488, ; 46: Syncfusion.Core.XForms => 0x1cd27163f7962630 => 75
	i64 2080779309381168229, ; 47: SVG.Forms.Plugin.Android => 0x1ce069c1e7a5ac65 => 72
	i64 2133195048986300728, ; 48: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 58
	i64 2136356949452311481, ; 49: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 172
	i64 2165725771938924357, ; 50: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 144
	i64 2254786158495914142, ; 51: Syncfusion.SfProgressBar.XForms.Android.dll => 0x1f4a9c10959dd89e => 83
	i64 2262844636196693701, ; 52: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 156
	i64 2284400282711631002, ; 53: System.Web.Services => 0x1fb3d1f42fd4249a => 223
	i64 2287834202362508563, ; 54: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 12
	i64 2318169270833697477, ; 55: AiForms.Effects.Droid => 0x202bcaab6d44d2c5 => 16
	i64 2329709569556905518, ; 56: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 164
	i64 2335503487726329082, ; 57: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 100
	i64 2337758774805907496, ; 58: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 98
	i64 2469392061734276978, ; 59: Syncfusion.Core.XForms.Android.dll => 0x22450aff2ad74f72 => 74
	i64 2470498323731680442, ; 60: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 150
	i64 2479423007379663237, ; 61: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 184
	i64 2497223385847772520, ; 62: System.Runtime => 0x22a7eb7046413568 => 99
	i64 2547086958574651984, ; 63: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 136
	i64 2568489860015129477, ; 64: Huawei.Hms.Availableupdate.dll => 0x23a51beb53650385 => 24
	i64 2592350477072141967, ; 65: System.Xml.dll => 0x23f9e10627330e8f => 103
	i64 2612152650457191105, ; 66: Microsoft.IdentityModel.Tokens.dll => 0x24403afeed9892c1 => 55
	i64 2624866290265602282, ; 67: mscorlib.dll => 0x246d65fbde2db8ea => 57
	i64 2656907746661064104, ; 68: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 48
	i64 2692509909129159130, ; 69: Plugin.XamarinFormsSaveOpenPDFPackage => 0x255db77f2fdce1da => 65
	i64 2694427813909235223, ; 70: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 176
	i64 2776255433543154418, ; 71: Huawei.Hmf.Tasks.dll => 0x26873d9b8a167af2 => 23
	i64 2783046991838674048, ; 72: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 98
	i64 2789714023057451704, ; 73: Microsoft.IdentityModel.JsonWebTokens.dll => 0x26b70e1f9943eab8 => 53
	i64 2949706848458024531, ; 74: Xamarin.Android.Support.SlidingPaneLayout => 0x28ef76c01de0a653 => 131
	i64 2960931600190307745, ; 75: Xamarin.Forms.Core => 0x2917579a49927da1 => 196
	i64 2973416776963745376, ; 76: XamForms.Controls.Calendar.dll => 0x2943b2ce081c6660 => 211
	i64 2977248461349026546, ; 77: Xamarin.Android.Support.DrawerLayout => 0x29514fb392c97af2 => 124
	i64 3017704767998173186, ; 78: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 201
	i64 3022227708164871115, ; 79: Xamarin.Android.Support.Media.Compat.dll => 0x29f11c168f8293cb => 129
	i64 3270330317141120886, ; 80: HrApp.Android.dll => 0x2d628c18b3631776 => 1
	i64 3289520064315143713, ; 81: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 163
	i64 3303437397778967116, ; 82: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 138
	i64 3311221304742556517, ; 83: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 97
	i64 3364695309916733813, ; 84: Xamarin.Firebase.Common => 0x2eb1cc8eb5028175 => 191
	i64 3402534845034375023, ; 85: System.IdentityModel.Tokens.Jwt.dll => 0x2f383b6a0629a76f => 92
	i64 3411255996856937470, ; 86: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 205
	i64 3493805808809882663, ; 87: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 182
	i64 3522470458906976663, ; 88: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 181
	i64 3530710316062465247, ; 89: Plugin.Multilingual => 0x30ff9a5371b5dcdf => 63
	i64 3531994851595924923, ; 90: System.Numerics => 0x31042a9aade235bb => 96
	i64 3571415421602489686, ; 91: System.Runtime.dll => 0x319037675df7e556 => 99
	i64 3643493506442034919, ; 92: NGraphics.Android.Custom.dll => 0x32904a0a40eb7ee7 => 59
	i64 3667526520489045555, ; 93: Huawei.Agconnect.AgconnectCore.dll => 0x32e5abf06212ee33 => 19
	i64 3674854143856381852, ; 94: XamSvg.Abstractions.dll => 0x32ffb45fa5ee8f9c => 213
	i64 3716579019761409177, ; 95: netstandard.dll => 0x3393f0ed5c8c5c99 => 2
	i64 3727469159507183293, ; 96: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 178
	i64 3756217500168923014, ; 97: Syncfusion.SfBusyIndicator.XForms => 0x3420c3ea44aca786 => 80
	i64 3765676030881038928, ; 98: SVG.Forms.Plugin.Android.dll => 0x34425e660fde0250 => 72
	i64 3772598417116884899, ; 99: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 157
	i64 3783726507060260521, ; 100: Microsoft.AspNetCore.SignalR.Common.dll => 0x34827f360c8e6ea9 => 43
	i64 3869221888984012293, ; 101: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 50
	i64 3966267475168208030, ; 102: System.Memory => 0x370b03412596249e => 94
	i64 4055376381221176420, ; 103: Huawei.Hms.NetworkGrs.dll => 0x3847975519328464 => 30
	i64 4201423742386704971, ; 104: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 151
	i64 4223289525753750523, ; 105: HrApp => 0x3a9c23729e2e23fb => 18
	i64 4247996603072512073, ; 106: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 207
	i64 4252163538099460320, ; 107: Xamarin.Android.Support.ViewPager.dll => 0x3b02b8357f4958e0 => 135
	i64 4349341163892612332, ; 108: Xamarin.Android.Support.DocumentFile => 0x3c5bf6bea8cd9cec => 123
	i64 4416987920449902723, ; 109: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0x3d4c4b1c879b9883 => 115
	i64 4525561845656915374, ; 110: System.ServiceModel.Internals => 0x3ece06856b710dae => 224
	i64 4587490706011065879, ; 111: XamSvg.Droid => 0x3faa0a7dd6320e17 => 214
	i64 4636684751163556186, ; 112: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 186
	i64 4706792261117077996, ; 113: Prism.Unity.Forms => 0x4151e29fb370e9ec => 69
	i64 4782108999019072045, ; 114: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 143
	i64 4794310189461587505, ; 115: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 136
	i64 4795410492532947900, ; 116: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 181
	i64 4841234827713643511, ; 117: Xamarin.Android.Support.CoordinaterLayout => 0x432f856d041f03f7 => 118
	i64 4877824738504089047, ; 118: Syncfusion.SfRangeSlider.Android => 0x43b183c17f261dd7 => 85
	i64 4930045999758365834, ; 119: XamSvg.Abstractions => 0x446b0ab75deed48a => 213
	i64 4963205065368577818, ; 120: Xamarin.Android.Support.LocalBroadcastManager.dll => 0x44e0d8b5f4b6a71a => 128
	i64 4998547060489277110, ; 121: Syncfusion.SfPdfViewer.XForms.dll => 0x455e68116d894eb6 => 82
	i64 5046316774542345679, ; 122: Huawei.Hms.Opendevice => 0x46081e5eb2b105cf => 31
	i64 5081566143765835342, ; 123: System.Resources.ResourceManager.dll => 0x4685597c05d06e4e => 3
	i64 5099468265966638712, ; 124: System.Resources.ResourceManager => 0x46c4f35ea8519678 => 3
	i64 5142919913060024034, ; 125: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 198
	i64 5178572682164047940, ; 126: Xamarin.Android.Support.Print.dll => 0x47ddfc6acbee1044 => 130
	i64 5203618020066742981, ; 127: Xamarin.Essentials => 0x4836f704f0e652c5 => 190
	i64 5205316157927637098, ; 128: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 170
	i64 5288341611614403055, ; 129: Xamarin.Android.Support.Interpolator.dll => 0x4963f6ad4b3179ef => 126
	i64 5348796042099802469, ; 130: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 171
	i64 5375264076663995773, ; 131: Xamarin.Forms.PancakeView => 0x4a98c632c779bd7d => 197
	i64 5376510917114486089, ; 132: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 184
	i64 5408338804355907810, ; 133: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 183
	i64 5446034149219586269, ; 134: System.Diagnostics.Debug => 0x4b94333452e150dd => 13
	i64 5451019430259338467, ; 135: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 149
	i64 5507995362134886206, ; 136: System.Core.dll => 0x4c705499688c873e => 89
	i64 5679624767254653100, ; 137: Syncfusion.SfProgressBar.XForms => 0x4ed214a245b968ac => 84
	i64 5692067934154308417, ; 138: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 188
	i64 5757522595884336624, ; 139: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 147
	i64 5767696078500135884, ; 140: Xamarin.Android.Support.Annotations.dll => 0x500af9065b6a03cc => 114
	i64 5775268978821181986, ; 141: Syncfusion.SfBusyIndicator.Android => 0x5025e0899cf83222 => 78
	i64 5814345312393086621, ; 142: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 176
	i64 5880868220621719076, ; 143: Huawei.Android.Hms.SecuritySsl.dll => 0x519d0a7d0d0a8624 => 22
	i64 5896680224035167651, ; 144: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 165
	i64 5975932659239009399, ; 145: AiForms.Effects.dll => 0x52eec7177b98bc77 => 15
	i64 6014447449592687183, ; 146: Microsoft.AspNetCore.Http.Connections.Common.dll => 0x53779c16e939ea4f => 39
	i64 6034224070161570862, ; 147: Microsoft.AspNetCore.SignalR.Client.dll => 0x53bdded235179c2e => 42
	i64 6044705416426755068, ; 148: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0x53e31b8ccdff13fc => 132
	i64 6085203216496545422, ; 149: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 199
	i64 6086316965293125504, ; 150: FormsViewGroup.dll => 0x5476f10882baef80 => 17
	i64 6092862891035488599, ; 151: Xamarin.Firebase.Measurement.Connector.dll => 0x548e32849d547157 => 194
	i64 6222399776351216807, ; 152: System.Text.Json.dll => 0x565a67a0ffe264a7 => 101
	i64 6227942033188892203, ; 153: Syncfusion.SfPdfViewer.XForms => 0x566e184839f2ae2b => 82
	i64 6300241346327543539, ; 154: Xamarin.Firebase.Iid => 0x576ef41fd714fef3 => 192
	i64 6311200438583329442, ; 155: Xamarin.Android.Support.LocalBroadcastManager => 0x5795e35c580c82a2 => 128
	i64 6319713645133255417, ; 156: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 166
	i64 6401687960814735282, ; 157: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 164
	i64 6479910363780928313, ; 158: Huawei.Android.Hms.SecuritySsl => 0x59ed4424d188d339 => 22
	i64 6504860066809920875, ; 159: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 144
	i64 6548213210057960872, ; 160: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 154
	i64 6554405243736097249, ; 161: Xamarin.GooglePlayServices.Stats => 0x5af5ecd7aad901e1 => 206
	i64 6560151584539558821, ; 162: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 51
	i64 6577563365557241066, ; 163: Syncfusion.SfRangeSlider.Android.dll => 0x5b48330813a984ea => 85
	i64 6588599331800941662, ; 164: Xamarin.Android.Support.v4 => 0x5b6f682f335f045e => 133
	i64 6591024623626361694, ; 165: System.Web.Services.dll => 0x5b7805f9751a1b5e => 223
	i64 6617685658146568858, ; 166: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 11
	i64 6659513131007730089, ; 167: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 160
	i64 6783125919820072783, ; 168: Microsoft.AspNetCore.Connections.Abstractions => 0x5e228115e59ec74f => 37
	i64 6814185388980153342, ; 169: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 228
	i64 6876862101832370452, ; 170: System.Xml.Linq => 0x5f6f85a57d108914 => 104
	i64 6894844156784520562, ; 171: System.Numerics.Vectors => 0x5faf683aead1ad72 => 97
	i64 7017588408768804231, ; 172: Microsoft.AspNetCore.SignalR.Protocols.Json => 0x61637b7a1c903587 => 44
	i64 7026608356547306326, ; 173: Syncfusion.Core.XForms.dll => 0x618387125bcb2356 => 75
	i64 7036436454368433159, ; 174: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 162
	i64 7103753931438454322, ; 175: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 159
	i64 7194160955514091247, ; 176: Xamarin.Android.Support.CursorAdapter.dll => 0x63d6cb45d266f6ef => 121
	i64 7204980051946441770, ; 177: XamForms.Controls.Calendar => 0x63fd3b2f020b0c2a => 211
	i64 7216222056629072044, ; 178: HrApp.resources => 0x64252bba31b6f0ac => 0
	i64 7270811800166795866, ; 179: System.Linq => 0x64e71ccf51a90a5a => 230
	i64 7338192458477945005, ; 180: System.Reflection => 0x65d67f295d0740ad => 7
	i64 7385250113861300937, ; 181: Xamarin.Firebase.Iid.Interop.dll => 0x667dadd98e1db2c9 => 193
	i64 7488575175965059935, ; 182: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 104
	i64 7489048572193775167, ; 183: System.ObjectModel => 0x67ee71ff6b419e3f => 236
	i64 7496222613193209122, ; 184: System.IdentityModel.Tokens.Jwt => 0x6807eec000a1b522 => 92
	i64 7500049668289977301, ; 185: Unity.Abstractions.dll => 0x6815876fb435dbd5 => 105
	i64 7635363394907363464, ; 186: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 196
	i64 7637365915383206639, ; 187: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 190
	i64 7654504624184590948, ; 188: System.Net.Http => 0x6a3a4366801b8264 => 95
	i64 7735176074855944702, ; 189: Microsoft.CSharp => 0x6b58dda848e391fe => 46
	i64 7735352534559001595, ; 190: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 210
	i64 7756332380610150586, ; 191: Xamarin.Google.AutoValue.Annotations => 0x6ba407349220c0ba => 202
	i64 7784126582539947449, ; 192: Huawei.Hms.Base => 0x6c06c5e27ef80db9 => 25
	i64 7820441508502274321, ; 193: System.Data => 0x6c87ca1e14ff8111 => 217
	i64 7821246742157274664, ; 194: Xamarin.Android.Support.AsyncLayoutInflater => 0x6c8aa67926f72e28 => 115
	i64 7836164640616011524, ; 195: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 139
	i64 8044118961405839122, ; 196: System.ComponentModel.Composition => 0x6fa2739369944712 => 222
	i64 8064050204834738623, ; 197: System.Collections.dll => 0x6fe942efa61731bf => 4
	i64 8083354569033831015, ; 198: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 163
	i64 8087206902342787202, ; 199: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 90
	i64 8101777744205214367, ; 200: Xamarin.Android.Support.Annotations => 0x706f4beeec84729f => 114
	i64 8103644804370223335, ; 201: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 219
	i64 8113615946733131500, ; 202: System.Reflection.Extensions => 0x70995ab73cf916ec => 8
	i64 8138104942271396658, ; 203: HrApp.resources.dll => 0x70f05b53d4effb32 => 0
	i64 8167236081217502503, ; 204: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 36
	i64 8185542183669246576, ; 205: System.Collections => 0x7198e33f4794aa70 => 4
	i64 8196541262927413903, ; 206: Xamarin.Android.Support.Interpolator => 0x71bff6d9fb9ec28f => 126
	i64 8243855692487634729, ; 207: Microsoft.AspNetCore.SignalR.Protocols.Json.dll => 0x72680f13124eaf29 => 44
	i64 8290740647658429042, ; 208: System.Runtime.Extensions => 0x730ea0b15c929a72 => 6
	i64 8375317123763839630, ; 209: Huawei.Hms.Device => 0x743b1a8cbb30a28e => 26
	i64 8385935383968044654, ; 210: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0x7460d3cd16cb566e => 112
	i64 8398329775253868912, ; 211: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 148
	i64 8400357532724379117, ; 212: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 175
	i64 8428678171113854126, ; 213: Xamarin.Firebase.Iid.dll => 0x74f8ae23bb5494ae => 192
	i64 8465511506719290632, ; 214: Xamarin.Firebase.Messaging.dll => 0x757b89dcf7fc3508 => 195
	i64 8479135282796081847, ; 215: AiForms.Effects => 0x75abf09d858ab2b7 => 15
	i64 8518502242792458212, ; 216: Huawei.Hms.Device.dll => 0x7637cca8280347e4 => 26
	i64 8601935802264776013, ; 217: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 183
	i64 8626175481042262068, ; 218: Java.Interop => 0x77b654e585b55834 => 36
	i64 8638972117149407195, ; 219: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 46
	i64 8639588376636138208, ; 220: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 174
	i64 8684531736582871431, ; 221: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 221
	i64 8725526185868997716, ; 222: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 90
	i64 8808820144457481518, ; 223: Xamarin.Android.Support.Loader.dll => 0x7a3f374010b17d2e => 127
	i64 8822867224128132893, ; 224: Huawei.Android.Hms.SecurityEncrypt.dll => 0x7a711efeaa98171d => 21
	i64 8844506025403580595, ; 225: Plugin.FirebasePushNotification => 0x7abdff5eb1fb80b3 => 61
	i64 8853378295825400934, ; 226: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 209
	i64 8854686927553911847, ; 227: Plugin.SharedTransitions.dll => 0x7ae22ad8b2255c27 => 64
	i64 8902821854310209666, ; 228: XamSvg.XamForms.dll => 0x7b8d2d4eacbe9882 => 216
	i64 8917102979740339192, ; 229: Xamarin.Android.Support.DocumentFile.dll => 0x7bbfe9ea4d000bf8 => 123
	i64 8941376889969657626, ; 230: System.Xml.XDocument => 0x7c1626e87187471a => 228
	i64 8963482838182047088, ; 231: Syncfusion.SfProgressBar.XForms.dll => 0x7c64b0269826ad70 => 84
	i64 9162065988803407493, ; 232: XamForms.Controls.Calendar.Droid.dll => 0x7f2632795f50ae85 => 212
	i64 9244338242424394172, ; 233: Huawei.Hms.NetworkGrs => 0x804a7ca72343d1bc => 30
	i64 9289084858135747932, ; 234: NGraphics.Android.Custom => 0x80e9757679a41d5c => 59
	i64 9312692141327339315, ; 235: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 188
	i64 9324707631942237306, ; 236: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 140
	i64 9427266486299436557, ; 237: Microsoft.IdentityModel.Logging.dll => 0x82d460ebe6d2a60d => 54
	i64 9501029730072421347, ; 238: Huawei.Hms.Push => 0x83da70336d6463e3 => 32
	i64 9584643793929893533, ; 239: System.IO.dll => 0x85037ebfbbd7f69d => 226
	i64 9646958908362757981, ; 240: Plugin.Multilingual.Abstractions.dll => 0x85e0e203efc0975d => 62
	i64 9659729154652888475, ; 241: System.Text.RegularExpressions => 0x860e407c9991dd9b => 229
	i64 9662334977499516867, ; 242: System.Numerics.dll => 0x8617827802b0cfc3 => 96
	i64 9678050649315576968, ; 243: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 150
	i64 9704315356731487263, ; 244: Plugin.FirebasePushNotification.dll => 0x86aca766ba59341f => 61
	i64 9711637524876806384, ; 245: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 171
	i64 9796610708422913120, ; 246: Xamarin.Firebase.Iid.Interop => 0x87f48d88de55ec60 => 193
	i64 9808709177481450983, ; 247: Mono.Android.dll => 0x881f890734e555e7 => 56
	i64 9825649861376906464, ; 248: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 147
	i64 9834056768316610435, ; 249: System.Transactions.dll => 0x8879968718899783 => 218
	i64 9850445980673189563, ; 250: HrApp.dll => 0x88b3d06df53326bb => 18
	i64 9866412715007501892, ; 251: Xamarin.Android.Arch.Lifecycle.Common.dll => 0x88ec8a16fd6b6644 => 109
	i64 9875200773399460291, ; 252: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 204
	i64 9998632235833408227, ; 253: Mono.Security => 0x8ac2470b209ebae3 => 234
	i64 10038780035334861115, ; 254: System.Net.Http.dll => 0x8b50e941206af13b => 95
	i64 10200434532125394699, ; 255: Huawei.Hmf.Tasks => 0x8d8f3929a9f6470b => 23
	i64 10219142040998308282, ; 256: Huawei.Hms.Base.dll => 0x8dd1af8afef6e9ba => 25
	i64 10229024438826829339, ; 257: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 154
	i64 10303855825347935641, ; 258: Xamarin.Android.Support.Loader => 0x8efea647eeb3fd99 => 127
	i64 10321854143672141184, ; 259: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 208
	i64 10352330178246763130, ; 260: Xamarin.Firebase.Measurement.Connector => 0x8faadd72b7f4627a => 194
	i64 10360651442923773544, ; 261: System.Text.Encoding => 0x8fc86d98211c1e68 => 9
	i64 10363495123250631811, ; 262: Xamarin.Android.Support.Collections.dll => 0x8fd287e80cd8d483 => 116
	i64 10376576884623852283, ; 263: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 182
	i64 10430153318873392755, ; 264: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 152
	i64 10447083246144586668, ; 265: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 45
	i64 10566960649245365243, ; 266: System.Globalization.dll => 0x92a562b96dcd13fb => 227
	i64 10635644668885628703, ; 267: Xamarin.Android.Support.DrawerLayout.dll => 0x93996679ee34771f => 124
	i64 10714184849103829812, ; 268: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 6
	i64 10810727582997339763, ; 269: Huawei.Hms.Availableupdate => 0x96076b758412de73 => 24
	i64 10847732767863316357, ; 270: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 141
	i64 10850923258212604222, ; 271: Xamarin.Android.Arch.Lifecycle.Runtime => 0x9696393672c9593e => 112
	i64 10895408586901726048, ; 272: Prism.Unity.Forms.dll => 0x973444622904a360 => 69
	i64 10964653383833615866, ; 273: System.Diagnostics.Tracing => 0x982a4628ccaffdfa => 231
	i64 11002576679268595294, ; 274: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 49
	i64 11023048688141570732, ; 275: System.Core => 0x98f9bc61168392ac => 89
	i64 11037814507248023548, ; 276: System.Xml => 0x992e31d0412bf7fc => 103
	i64 11050168729868392624, ; 277: Microsoft.AspNetCore.Http.Features => 0x995a15e9dbef58b0 => 40
	i64 11122995063473561350, ; 278: Xamarin.CommunityToolkit.dll => 0x9a5cd113fcc3df06 => 189
	i64 11162124722117608902, ; 279: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 187
	i64 11221835998582316105, ; 280: Huawei.Hms.Ui => 0x9bbbf86287309c49 => 34
	i64 11226290749488709958, ; 281: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 51
	i64 11237162742616054720, ; 282: Polly => 0x9bf26bfa34e25bc0 => 66
	i64 11340910727871153756, ; 283: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 153
	i64 11345533118204769135, ; 284: XamForms.Controls.Calendar.Droid => 0x9d736e428206736f => 212
	i64 11356770688168724568, ; 285: SVG.Forms.Plugin.Abstractions => 0x9d9b5ac527dd8858 => 71
	i64 11376461258732682436, ; 286: Xamarin.Android.Support.Compat => 0x9de14f3d5fc13cc4 => 117
	i64 11392833485892708388, ; 287: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 177
	i64 11432101114902388181, ; 288: System.AppContext => 0x9ea6fb64e61a9dd5 => 233
	i64 11474967336136963068, ; 289: Huawei.Hms.Hatool => 0x9f3f45fec7a773fc => 27
	i64 11485890710487134646, ; 290: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 232
	i64 11513602507638267977, ; 291: System.IO.Pipelines.dll => 0x9fc8887aa0d36049 => 93
	i64 11529969570048099689, ; 292: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 187
	i64 11530571088791430846, ; 293: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 50
	i64 11574338195132234057, ; 294: Syncfusion.SfRangeSlider.XForms.Android.dll => 0xa0a04f43d717b949 => 86
	i64 11578238080964724296, ; 295: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 162
	i64 11580057168383206117, ; 296: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 137
	i64 11597940890313164233, ; 297: netstandard => 0xa0f429ca8d1805c9 => 2
	i64 11672361001936329215, ; 298: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 159
	i64 11743665907891708234, ; 299: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 237
	i64 11758626982801240232, ; 300: Syncfusion.SfBusyIndicator.XForms.Android.dll => 0xa32f08f0e430f0a8 => 79
	i64 11834399401546345650, ; 301: Xamarin.Android.Support.SlidingPaneLayout.dll => 0xa43c3b8deb43ecb2 => 131
	i64 11865714326292153359, ; 302: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa4ab7c5000e8440f => 111
	i64 11986148774707385255, ; 303: XamSvg.Shared.dll => 0xa6575ace256ad3a7 => 215
	i64 12102847907131387746, ; 304: System.Buffers => 0xa7f5f40c43256f62 => 88
	i64 12123043025855404482, ; 305: System.Reflection.Extensions.dll => 0xa83db366c0e359c2 => 8
	i64 12137774235383566651, ; 306: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 185
	i64 12145679461940342714, ; 307: System.Text.Json => 0xa88e1f1ebcb62fba => 101
	i64 12212747205940921632, ; 308: Syncfusion.SfProgressBar.XForms.Android => 0xa97c64e0bdc0c520 => 83
	i64 12313367145828839434, ; 309: System.IO.Pipelines => 0xaae1de2e1c17f00a => 93
	i64 12361596062003817520, ; 310: Plugin.Multilingual.dll => 0xab8d361fb49aec30 => 63
	i64 12388767885335911387, ; 311: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0xabedbec0d236dbdb => 111
	i64 12414299427252656003, ; 312: Xamarin.Android.Support.Compat.dll => 0xac48738e28bad783 => 117
	i64 12439275739440478309, ; 313: Microsoft.IdentityModel.JsonWebTokens => 0xaca12f61007bf865 => 53
	i64 12451044538927396471, ; 314: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 158
	i64 12466513435562512481, ; 315: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 169
	i64 12487638416075308985, ; 316: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 155
	i64 12538491095302438457, ; 317: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 145
	i64 12550732019250633519, ; 318: System.IO.Compression => 0xae2d28465e8e1b2f => 220
	i64 12700543734426720211, ; 319: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 146
	i64 12708238894395270091, ; 320: System.IO => 0xb05cbbf17d3ba3cb => 226
	i64 12711617764981604187, ; 321: Huawei.Android.Hms.SecurityEncrypt => 0xb068bd021a45ff5b => 21
	i64 12832250852553794196, ; 322: Syncfusion.SfBusyIndicator.XForms.dll => 0xb2155029872c2294 => 80
	i64 12843321153144804894, ; 323: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 52
	i64 12843770487262409629, ; 324: System.AppContext.dll => 0xb23e3d357debf39d => 233
	i64 12876461035432930612, ; 325: Huawei.Hms.Hatool.dll => 0xb2b26116dd236d34 => 27
	i64 12952608645614506925, ; 326: Xamarin.Android.Support.Core.Utils => 0xb3c0e8eff48193ad => 120
	i64 12953969983053113793, ; 327: Prism.Forms => 0xb3c5bf1106f429c1 => 68
	i64 12963446364377008305, ; 328: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 10
	i64 13196197655982686080, ; 329: Prism => 0xb7224fda06b0bf80 => 67
	i64 13280903765250193763, ; 330: Unity.Abstractions => 0xb84f3f9bf7e2b963 => 105
	i64 13295219713260136977, ; 331: Microsoft.AspNetCore.Http.Connections.Client => 0xb8821be35ba42a11 => 38
	i64 13297997883559027856, ; 332: Syncfusion.Compression.Portable => 0xb88bfa9e896ea490 => 73
	i64 13358059602087096138, ; 333: Xamarin.Android.Support.Fragment.dll => 0xb9615c6f1ee5af4a => 125
	i64 13370592475155966277, ; 334: System.Runtime.Serialization => 0xb98de304062ea945 => 14
	i64 13401370062847626945, ; 335: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 185
	i64 13404347523447273790, ; 336: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 148
	i64 13428779960367410341, ; 337: Microsoft.AspNetCore.SignalR.Client.Core.dll => 0xba5c9c39a8956ca5 => 41
	i64 13454009404024712428, ; 338: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 203
	i64 13465488254036897740, ; 339: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 210
	i64 13491513212026656886, ; 340: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 142
	i64 13572454107664307259, ; 341: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 178
	i64 13622732128915678507, ; 342: Syncfusion.Core.XForms.Android => 0xbd0daab1e651e52b => 74
	i64 13647894001087880694, ; 343: System.Data.dll => 0xbd670f48cb071df6 => 217
	i64 13828521679616088467, ; 344: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 209
	i64 13842256465236365716, ; 345: Syncfusion.SfRangeSlider.XForms => 0xc01992ea6c449194 => 87
	i64 13852575513600495870, ; 346: ImageCircle.Forms.Plugin.dll => 0xc03e3c09186e90fe => 35
	i64 13901627684715465194, ; 347: SVG.Forms.Plugin.Abstractions.dll => 0xc0ec80b9ab3389ea => 71
	i64 13959074834287824816, ; 348: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 158
	i64 13967638549803255703, ; 349: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 198
	i64 13970307180132182141, ; 350: Syncfusion.Licensing => 0xc1e0805ccade287d => 76
	i64 14124974489674258913, ; 351: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 145
	i64 14125464355221830302, ; 352: System.Threading.dll => 0xc407bafdbc707a9e => 5
	i64 14172845254133543601, ; 353: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 172
	i64 14212104595480609394, ; 354: System.Security.Cryptography.Cng.dll => 0xc53b89d4a4518272 => 225
	i64 14261073672896646636, ; 355: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 177
	i64 14327695147300244862, ; 356: System.Reflection.dll => 0xc6d632d338eb4d7e => 7
	i64 14400856865250966808, ; 357: Xamarin.Android.Support.Core.UI => 0xc7da1f051a877d18 => 119
	i64 14438260825521943376, ; 358: RestSharp.dll => 0xc85f01b93fac7350 => 70
	i64 14486659737292545672, ; 359: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 165
	i64 14538127318538747197, ; 360: Syncfusion.Licensing.dll => 0xc9c1cdc518e77d3d => 76
	i64 14551742072151931844, ; 361: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 100
	i64 14604329626201521481, ; 362: Microsoft.AspNetCore.SignalR.Client => 0xcaad006b00747d49 => 42
	i64 14644440854989303794, ; 363: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 170
	i64 14661790646341542033, ; 364: Xamarin.Android.Support.SwipeRefreshLayout => 0xcb7924e94e552091 => 132
	i64 14669215534098758659, ; 365: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 48
	i64 14748851336349168659, ; 366: Syncfusion.Pdf.Portable.dll => 0xccae7225cc233413 => 77
	i64 14789919016435397935, ; 367: Xamarin.Firebase.Common.dll => 0xcd4058fc2f6d352f => 191
	i64 14792063746108907174, ; 368: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 203
	i64 14809184851036126845, ; 369: Microsoft.AspNetCore.SignalR.Client.Core => 0xcd84cb28db1abe7d => 41
	i64 14809388726477333247, ; 370: Xamarin.GooglePlayServices.Stats.dll => 0xcd8584954e5b22ff => 206
	i64 14852515768018889994, ; 371: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 153
	i64 14890749653179496492, ; 372: Huawei.Hms.Log.dll => 0xcea691ea3d08f82c => 28
	i64 14935719434541007538, ; 373: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 11
	i64 14954917835170835695, ; 374: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 47
	i64 14970123681643361337, ; 375: Plugin.Multilingual.Abstractions => 0xcfc0902c6003f439 => 62
	i64 14987728460634540364, ; 376: System.IO.Compression.dll => 0xcfff1ba06622494c => 220
	i64 14988210264188246988, ; 377: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 155
	i64 15066237768853720495, ; 378: Huawei.Hms.NetworkCommon => 0xd116076d2a198daf => 29
	i64 15076659072870671916, ; 379: System.ObjectModel.dll => 0xd13b0d8c1620662c => 236
	i64 15088973192230695711, ; 380: NGraphics.Custom.dll => 0xd166cd2c6c4d731f => 60
	i64 15133485256822086103, ; 381: System.Linq.dll => 0xd204f0a9127dd9d7 => 230
	i64 15188640517174936311, ; 382: Xamarin.Android.Arch.Core.Common => 0xd2c8e413d75142f7 => 107
	i64 15216786773475677495, ; 383: Plugin.XamarinFormsSaveOpenPDFPackage.dll => 0xd32ce2f2cfe15537 => 65
	i64 15246441518555807158, ; 384: Xamarin.Android.Arch.Core.Common.dll => 0xd3963dc832493db6 => 107
	i64 15326820765897713587, ; 385: Xamarin.Android.Arch.Core.Runtime.dll => 0xd4b3ce481769e7b3 => 108
	i64 15370334346939861994, ; 386: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 152
	i64 15377983283090003614, ; 387: Syncfusion.SfBusyIndicator.Android.dll => 0xd5699251e679969e => 78
	i64 15391712275433856905, ; 388: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 47
	i64 15440341663105042387, ; 389: XamSvg.XamForms => 0xd6471cefa80a47d3 => 216
	i64 15457813392950723921, ; 390: Xamarin.Android.Support.Media.Compat => 0xd6852f61c31a8551 => 129
	i64 15460377942336190536, ; 391: Huawei.Android.Hms.SecurityBase.dll => 0xd68e4bd3723bb848 => 20
	i64 15526743539506359484, ; 392: System.Text.Encoding.dll => 0xd77a12fc26de2cbc => 9
	i64 15568534730848034786, ; 393: Xamarin.Android.Support.VersionedParcelable.dll => 0xd80e8bda21875fe2 => 134
	i64 15582737692548360875, ; 394: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 168
	i64 15609085926864131306, ; 395: System.dll => 0xd89e9cf3334914ea => 91
	i64 15663313122684323054, ; 396: NGraphics.Custom => 0xd95f444c1b5044ee => 60
	i64 15777549416145007739, ; 397: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 180
	i64 15810740023422282496, ; 398: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 200
	i64 15817206913877585035, ; 399: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 237
	i64 15847085070278954535, ; 400: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 102
	i64 15852824340364052161, ; 401: Microsoft.AspNetCore.Http.Features.dll => 0xdc008bbee610c6c1 => 40
	i64 15897019536993143047, ; 402: XamSvg.Droid.dll => 0xdc9d8f0af9ebc907 => 214
	i64 15930129725311349754, ; 403: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 207
	i64 15937190497610202713, ; 404: System.Security.Cryptography.Cng => 0xdd2c465197c97e59 => 225
	i64 15963349826457351533, ; 405: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 235
	i64 15992843576024808175, ; 406: Huawei.Hms.Ui.dll => 0xddf1fe7fa958baef => 34
	i64 16010501072521946958, ; 407: Huawei.Hms.NetworkCommon.dll => 0xde30b9e5efae674e => 29
	i64 16035518054986892682, ; 408: Prism.dll => 0xde899ab610db458a => 67
	i64 16154507427712707110, ; 409: System => 0xe03056ea4e39aa26 => 91
	i64 16156430004425724367, ; 410: Microsoft.AspNetCore.Http.Connections.Client.dll => 0xe0372b7d144211cf => 38
	i64 16242842420508142678, ; 411: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe16a2b1f8908ac56 => 118
	i64 16321164108206115771, ; 412: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 49
	i64 16358326039458771190, ; 413: Huawei.Hms.Stats.dll => 0xe30472dcddf670f6 => 33
	i64 16505967687213018679, ; 414: Huawei.Hms.Stats => 0xe510fa28be686e37 => 33
	i64 16527749710595459278, ; 415: Syncfusion.Compression.Portable.dll => 0xe55e5ccb449b88ce => 73
	i64 16565028646146589191, ; 416: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 222
	i64 16605226748660468415, ; 417: Microsoft.AspNetCore.SignalR.Common => 0xe6719dbfe8b8cabf => 43
	i64 16608271216877230369, ; 418: Unity.Container => 0xe67c6ead674fd921 => 106
	i64 16621146507174665210, ; 419: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 149
	i64 16677317093839702854, ; 420: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 175
	i64 16700268707773170941, ; 421: Syncfusion.SfPdfViewer.XForms.Android.dll => 0xe7c345e86c6444fd => 81
	i64 16767985610513713374, ; 422: Xamarin.Android.Arch.Core.Runtime => 0xe8b3da12798808de => 108
	i64 16822611501064131242, ; 423: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 219
	i64 16833383113903931215, ; 424: mscorlib => 0xe99c30c1484d7f4f => 57
	i64 16890310621557459193, ; 425: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 229
	i64 16904434304620314439, ; 426: Huawei.Agconnect.AgconnectCore => 0xea989d6fbfd23f47 => 19
	i64 16932527889823454152, ; 427: Xamarin.Android.Support.Core.Utils.dll => 0xeafc6c67465253c8 => 120
	i64 16955506688107500054, ; 428: Syncfusion.Pdf.Portable => 0xeb4e0f7fab685216 => 77
	i64 17024911836938395553, ; 429: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 138
	i64 17031351772568316411, ; 430: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 173
	i64 17037200463775726619, ; 431: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 161
	i64 17118171214553292978, ; 432: System.Threading.Channels => 0xed8ff6060fc420b2 => 102
	i64 17137864900836977098, ; 433: Microsoft.IdentityModel.Tokens => 0xedd5ed53b705e9ca => 55
	i64 17151170952569239713, ; 434: RestSharp => 0xee05331c4de338a1 => 70
	i64 17158783226145295961, ; 435: Plugin.SharedTransitions => 0xee203e6edc524e59 => 64
	i64 17333249706306540043, ; 436: System.Diagnostics.Tracing.dll => 0xf08c12c5bb8b920b => 231
	i64 17337559581350925250, ; 437: Syncfusion.SfRangeSlider.XForms.dll => 0xf09b6294b69793c2 => 87
	i64 17383232329670771222, ; 438: Xamarin.Android.Support.CustomView.dll => 0xf13da5b41a1cc216 => 122
	i64 17428701562824544279, ; 439: Xamarin.Android.Support.Core.UI.dll => 0xf1df2fbaec73d017 => 119
	i64 17483646997724851973, ; 440: Xamarin.Android.Support.ViewPager => 0xf2a2644fe5b6ef05 => 135
	i64 17524135665394030571, ; 441: Xamarin.Android.Support.Print => 0xf3323c8a739097eb => 130
	i64 17544493274320527064, ; 442: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 143
	i64 17571845317586269034, ; 443: Microsoft.AspNetCore.Connections.Abstractions.dll => 0xf3dbbc377ad7336a => 37
	i64 17609290784187047109, ; 444: Huawei.Android.Hms.SecurityBase => 0xf460c4ab92075cc5 => 20
	i64 17627500474728259406, ; 445: System.Globalization => 0xf4a176498a351f4e => 227
	i64 17636563193350668017, ; 446: Microsoft.AspNetCore.Http.Connections.Common => 0xf4c1a8c826653ef1 => 39
	i64 17666959971718154066, ; 447: Xamarin.Android.Support.CustomView => 0xf52da67d9f4e4752 => 122
	i64 17675249797910273188, ; 448: Polly.dll => 0xf54b1a0b30bc9ca4 => 66
	i64 17685921127322830888, ; 449: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 13
	i64 17704177640604968747, ; 450: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 169
	i64 17710060891934109755, ; 451: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 167
	i64 17712670374920797664, ; 452: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 232
	i64 17760961058993581169, ; 453: Xamarin.Android.Arch.Lifecycle.Common => 0xf67b9bfb46dbac71 => 109
	i64 17790600151040787804, ; 454: Microsoft.IdentityModel.Logging => 0xf6e4e89427cc055c => 54
	i64 17827832363535584534, ; 455: Xamarin.Forms.PancakeView.dll => 0xf7692f1427c04d16 => 197
	i64 17838668724098252521, ; 456: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 88
	i64 17841643939744178149, ; 457: Xamarin.Android.Arch.Lifecycle.ViewModel => 0xf79a40a25573dfe5 => 113
	i64 17882897186074144999, ; 458: FormsViewGroup => 0xf82cd03e3ac830e7 => 17
	i64 17891337867145587222, ; 459: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 208
	i64 17892495832318972303, ; 460: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 200
	i64 17928294245072900555, ; 461: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 221
	i64 17957010574918374872, ; 462: XamSvg.Shared => 0xf9341dfa41f155d8 => 215
	i64 17958105683855786126, ; 463: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xf93801f92d25c08e => 110
	i64 17986907704309214542, ; 464: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 205
	i64 18025913125965088385, ; 465: System.Threading => 0xfa28e87b91334681 => 5
	i64 18116111925905154859, ; 466: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 142
	i64 18121036031235206392, ; 467: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 173
	i64 18121944136070456290, ; 468: Huawei.Hms.Opendevice.dll => 0xfb7e142d75f3e3e2 => 31
	i64 18129453464017766560, ; 469: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 224
	i64 18245806341561545090, ; 470: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 12
	i64 18301997741680159453, ; 471: Xamarin.Android.Support.CursorAdapter => 0xfdfdc1fa58d8eadd => 121
	i64 18305135509493619199, ; 472: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 174
	i64 18337470502355292274, ; 473: Xamarin.Firebase.Messaging => 0xfe7bc8440c175072 => 195
	i64 18380184030268848184, ; 474: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 186
	i64 18434045720645380019 ; 475: Prism.Forms.dll => 0xffd2e2ea4860a7b3 => 68
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [476 x i32] [
	i32 157, i32 52, i32 56, i32 106, i32 146, i32 179, i32 180, i32 151, ; 0..7
	i32 35, i32 113, i32 1, i32 166, i32 204, i32 10, i32 160, i32 79, ; 8..15
	i32 116, i32 110, i32 156, i32 86, i32 218, i32 32, i32 199, i32 234, ; 16..23
	i32 201, i32 81, i32 141, i32 125, i32 14, i32 134, i32 202, i32 139, ; 24..31
	i32 168, i32 161, i32 58, i32 94, i32 140, i32 16, i32 179, i32 45, ; 32..39
	i32 137, i32 133, i32 167, i32 189, i32 235, i32 28, i32 75, i32 72, ; 40..47
	i32 58, i32 172, i32 144, i32 83, i32 156, i32 223, i32 12, i32 16, ; 48..55
	i32 164, i32 100, i32 98, i32 74, i32 150, i32 184, i32 99, i32 136, ; 56..63
	i32 24, i32 103, i32 55, i32 57, i32 48, i32 65, i32 176, i32 23, ; 64..71
	i32 98, i32 53, i32 131, i32 196, i32 211, i32 124, i32 201, i32 129, ; 72..79
	i32 1, i32 163, i32 138, i32 97, i32 191, i32 92, i32 205, i32 182, ; 80..87
	i32 181, i32 63, i32 96, i32 99, i32 59, i32 19, i32 213, i32 2, ; 88..95
	i32 178, i32 80, i32 72, i32 157, i32 43, i32 50, i32 94, i32 30, ; 96..103
	i32 151, i32 18, i32 207, i32 135, i32 123, i32 115, i32 224, i32 214, ; 104..111
	i32 186, i32 69, i32 143, i32 136, i32 181, i32 118, i32 85, i32 213, ; 112..119
	i32 128, i32 82, i32 31, i32 3, i32 3, i32 198, i32 130, i32 190, ; 120..127
	i32 170, i32 126, i32 171, i32 197, i32 184, i32 183, i32 13, i32 149, ; 128..135
	i32 89, i32 84, i32 188, i32 147, i32 114, i32 78, i32 176, i32 22, ; 136..143
	i32 165, i32 15, i32 39, i32 42, i32 132, i32 199, i32 17, i32 194, ; 144..151
	i32 101, i32 82, i32 192, i32 128, i32 166, i32 164, i32 22, i32 144, ; 152..159
	i32 154, i32 206, i32 51, i32 85, i32 133, i32 223, i32 11, i32 160, ; 160..167
	i32 37, i32 228, i32 104, i32 97, i32 44, i32 75, i32 162, i32 159, ; 168..175
	i32 121, i32 211, i32 0, i32 230, i32 7, i32 193, i32 104, i32 236, ; 176..183
	i32 92, i32 105, i32 196, i32 190, i32 95, i32 46, i32 210, i32 202, ; 184..191
	i32 25, i32 217, i32 115, i32 139, i32 222, i32 4, i32 163, i32 90, ; 192..199
	i32 114, i32 219, i32 8, i32 0, i32 36, i32 4, i32 126, i32 44, ; 200..207
	i32 6, i32 26, i32 112, i32 148, i32 175, i32 192, i32 195, i32 15, ; 208..215
	i32 26, i32 183, i32 36, i32 46, i32 174, i32 221, i32 90, i32 127, ; 216..223
	i32 21, i32 61, i32 209, i32 64, i32 216, i32 123, i32 228, i32 84, ; 224..231
	i32 212, i32 30, i32 59, i32 188, i32 140, i32 54, i32 32, i32 226, ; 232..239
	i32 62, i32 229, i32 96, i32 150, i32 61, i32 171, i32 193, i32 56, ; 240..247
	i32 147, i32 218, i32 18, i32 109, i32 204, i32 234, i32 95, i32 23, ; 248..255
	i32 25, i32 154, i32 127, i32 208, i32 194, i32 9, i32 116, i32 182, ; 256..263
	i32 152, i32 45, i32 227, i32 124, i32 6, i32 24, i32 141, i32 112, ; 264..271
	i32 69, i32 231, i32 49, i32 89, i32 103, i32 40, i32 189, i32 187, ; 272..279
	i32 34, i32 51, i32 66, i32 153, i32 212, i32 71, i32 117, i32 177, ; 280..287
	i32 233, i32 27, i32 232, i32 93, i32 187, i32 50, i32 86, i32 162, ; 288..295
	i32 137, i32 2, i32 159, i32 237, i32 79, i32 131, i32 111, i32 215, ; 296..303
	i32 88, i32 8, i32 185, i32 101, i32 83, i32 93, i32 63, i32 111, ; 304..311
	i32 117, i32 53, i32 158, i32 169, i32 155, i32 145, i32 220, i32 146, ; 312..319
	i32 226, i32 21, i32 80, i32 52, i32 233, i32 27, i32 120, i32 68, ; 320..327
	i32 10, i32 67, i32 105, i32 38, i32 73, i32 125, i32 14, i32 185, ; 328..335
	i32 148, i32 41, i32 203, i32 210, i32 142, i32 178, i32 74, i32 217, ; 336..343
	i32 209, i32 87, i32 35, i32 71, i32 158, i32 198, i32 76, i32 145, ; 344..351
	i32 5, i32 172, i32 225, i32 177, i32 7, i32 119, i32 70, i32 165, ; 352..359
	i32 76, i32 100, i32 42, i32 170, i32 132, i32 48, i32 77, i32 191, ; 360..367
	i32 203, i32 41, i32 206, i32 153, i32 28, i32 11, i32 47, i32 62, ; 368..375
	i32 220, i32 155, i32 29, i32 236, i32 60, i32 230, i32 107, i32 65, ; 376..383
	i32 107, i32 108, i32 152, i32 78, i32 47, i32 216, i32 129, i32 20, ; 384..391
	i32 9, i32 134, i32 168, i32 91, i32 60, i32 180, i32 200, i32 237, ; 392..399
	i32 102, i32 40, i32 214, i32 207, i32 225, i32 235, i32 34, i32 29, ; 400..407
	i32 67, i32 91, i32 38, i32 118, i32 49, i32 33, i32 33, i32 73, ; 408..415
	i32 222, i32 43, i32 106, i32 149, i32 175, i32 81, i32 108, i32 219, ; 416..423
	i32 57, i32 229, i32 19, i32 120, i32 77, i32 138, i32 173, i32 161, ; 424..431
	i32 102, i32 55, i32 70, i32 64, i32 231, i32 87, i32 122, i32 119, ; 432..439
	i32 135, i32 130, i32 143, i32 37, i32 20, i32 227, i32 39, i32 122, ; 440..447
	i32 66, i32 13, i32 169, i32 167, i32 232, i32 109, i32 54, i32 197, ; 448..455
	i32 88, i32 113, i32 17, i32 208, i32 200, i32 221, i32 215, i32 110, ; 456..463
	i32 205, i32 5, i32 142, i32 173, i32 31, i32 224, i32 12, i32 121, ; 464..471
	i32 174, i32 195, i32 186, i32 68 ; 472..475
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
