
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.5.30319.0



// Metadata version: v4.0.30319
.module extern 'ClrBootstrap.dll'
.module extern 'kernel32'
.assembly extern 'mscorlib'
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 ) 
  .ver 4:0:0:0
}
.assembly extern 'System.Runtime'
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 7:0:0:0
}
.assembly extern 'System.Runtime.InteropServices'
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 7:0:0:0
}
.assembly extern 'System.Windows.Forms'
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly 'RoseHackDLL'
{
  .custom instance void ['System.Runtime']'System.Runtime.CompilerServices'.'CompilationRelaxationsAttribute'::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void ['System.Runtime']'System.Runtime.CompilerServices'.'RuntimeCompatibilityAttribute'::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                         63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void ['System.Runtime']'System.Diagnostics'.'DebuggableAttribute'::.ctor(valuetype ['System.Runtime']'System.Diagnostics'.'DebuggableAttribute'/'DebuggingModes') = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void ['System.Runtime']'System.Runtime.Versioning'.'TargetFrameworkAttribute'::.ctor(string) = ( 01 00 18 2E 4E 45 54 43 6F 72 65 41 70 70 2C 56   // ....NETCoreApp,V
                                                                                                                    65 72 73 69 6F 6E 3D 76 37 2E 30 01 00 54 0E 14   // ersion=v7.0..T..
                                                                                                                    46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C 61 79   // FrameworkDisplay
                                                                                                                    4E 61 6D 65 08 2E 4E 45 54 20 37 2E 30 )          // Name..NET 7.0
  .custom instance void ['System.Runtime']'System.Reflection'.'AssemblyCompanyAttribute'::.ctor(string) = ( 01 00 0B 52 6F 73 65 48 61 63 6B 44 4C 4C 00 00 ) // ...RoseHackDLL..
  .custom instance void ['System.Runtime']'System.Reflection'.'AssemblyConfigurationAttribute'::.ctor(string) = ( 01 00 05 44 65 62 75 67 00 00 )                   // ...Debug..
  .custom instance void ['System.Runtime']'System.Reflection'.'AssemblyFileVersionAttribute'::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void ['System.Runtime']'System.Reflection'.'AssemblyInformationalVersionAttribute'::.ctor(string) = ( 01 00 05 31 2E 30 2E 30 00 00 )                   // ...1.0.0..
  .custom instance void ['System.Runtime']'System.Reflection'.'AssemblyProductAttribute'::.ctor(string) = ( 01 00 0B 52 6F 73 65 48 61 63 6B 44 4C 4C 00 00 ) // ...RoseHackDLL..
  .custom instance void ['System.Runtime']'System.Reflection'.'AssemblyTitleAttribute'::.ctor(string) = ( 01 00 0B 52 6F 73 65 48 61 63 6B 44 4C 4C 00 00 ) // ...RoseHackDLL..
  .permissionset reqmin
             = {['System.Runtime']'System.Security.Permissions'.'SecurityPermissionAttribute' = {property bool 'SkipVerification' = bool(true)}}
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module 'RoseHackDLL.dll'
// MVID: {C209DEEC-E682-4BF5-B522-904E41FD78B0}
.custom instance void ['System.Runtime']'System.Security'.'UnverifiableCodeAttribute'::.ctor() = ( 01 00 00 00 ) 
.custom instance void 'System.Runtime.CompilerServices'.'RefSafetyRulesAttribute'::.ctor(int32) = ( 01 00 0B 00 00 00 00 00 ) 
.imagebase 0x0000000180000000
.file alignment 0x00000200
.stackreserve 0x0000000000400000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000000
// Image base: 0x009F0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi sealed beforefieldinit 'Microsoft.CodeAnalysis'.'EmbeddedAttribute'
       extends ['System.Runtime']'System'.'Attribute'
{
  .custom instance void ['System.Runtime']'System.Runtime.CompilerServices'.'CompilerGeneratedAttribute'::.ctor() = ( 01 00 00 00 ) 
  .custom instance void 'Microsoft.CodeAnalysis'.'EmbeddedAttribute'::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void ['System.Runtime']'System'.'Attribute'::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method 'EmbeddedAttribute'::.ctor

} // end of class 'Microsoft.CodeAnalysis'.'EmbeddedAttribute'

.class private auto ansi sealed beforefieldinit 'System.Runtime.CompilerServices'.'NullableAttribute'
       extends ['System.Runtime']'System'.'Attribute'
{
  .custom instance void ['System.Runtime']'System.Runtime.CompilerServices'.'CompilerGeneratedAttribute'::.ctor() = ( 01 00 00 00 ) 
  .custom instance void 'Microsoft.CodeAnalysis'.'EmbeddedAttribute'::.ctor() = ( 01 00 00 00 ) 
  .custom instance void ['System.Runtime']'System'.'AttributeUsageAttribute'::.ctor(valuetype ['System.Runtime']'System'.'AttributeTargets') = ( 01 00 84 6B 00 00 02 00 54 02 0D 41 6C 6C 6F 77   // ...k....T..Allow
                                                                                                                                                 4D 75 6C 74 69 70 6C 65 00 54 02 09 49 6E 68 65   // Multiple.T..Inhe
                                                                                                                                                 72 69 74 65 64 00 )                               // rited.
  .field public initonly uint8[] 'NullableFlags'
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(uint8 'A_1') cil managed
  {
    // Code size       24 (0x18)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void ['System.Runtime']'System'.'Attribute'::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldc.i4.1
    IL_0009:  newarr     ['System.Runtime']'System'.'Byte'
    IL_000e:  dup
    IL_000f:  ldc.i4.0
    IL_0010:  ldarg.1
    IL_0011:  stelem.i1
    IL_0012:  stfld      uint8[] 'System.Runtime.CompilerServices'.'NullableAttribute'::'NullableFlags'
    IL_0017:  ret
  } // end of method 'NullableAttribute'::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(uint8[] 'A_1') cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void ['System.Runtime']'System'.'Attribute'::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      uint8[] 'System.Runtime.CompilerServices'.'NullableAttribute'::'NullableFlags'
    IL_000e:  ret
  } // end of method 'NullableAttribute'::.ctor

} // end of class 'System.Runtime.CompilerServices'.'NullableAttribute'

.class private auto ansi sealed beforefieldinit 'System.Runtime.CompilerServices'.'NullableContextAttribute'
       extends ['System.Runtime']'System'.'Attribute'
{
  .custom instance void ['System.Runtime']'System.Runtime.CompilerServices'.'CompilerGeneratedAttribute'::.ctor() = ( 01 00 00 00 ) 
  .custom instance void 'Microsoft.CodeAnalysis'.'EmbeddedAttribute'::.ctor() = ( 01 00 00 00 ) 
  .custom instance void ['System.Runtime']'System'.'AttributeUsageAttribute'::.ctor(valuetype ['System.Runtime']'System'.'AttributeTargets') = ( 01 00 4C 14 00 00 02 00 54 02 0D 41 6C 6C 6F 77   // ..L.....T..Allow
                                                                                                                                                 4D 75 6C 74 69 70 6C 65 00 54 02 09 49 6E 68 65   // Multiple.T..Inhe
                                                                                                                                                 72 69 74 65 64 00 )                               // rited.
  .field public initonly uint8 'Flag'
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(uint8 'A_1') cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void ['System.Runtime']'System'.'Attribute'::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      uint8 'System.Runtime.CompilerServices'.'NullableContextAttribute'::'Flag'
    IL_000e:  ret
  } // end of method 'NullableContextAttribute'::.ctor

} // end of class 'System.Runtime.CompilerServices'.'NullableContextAttribute'

.class private auto ansi sealed beforefieldinit 'System.Runtime.CompilerServices'.'RefSafetyRulesAttribute'
       extends ['System.Runtime']'System'.'Attribute'
{
  .custom instance void ['System.Runtime']'System.Runtime.CompilerServices'.'CompilerGeneratedAttribute'::.ctor() = ( 01 00 00 00 ) 
  .custom instance void 'Microsoft.CodeAnalysis'.'EmbeddedAttribute'::.ctor() = ( 01 00 00 00 ) 
  .custom instance void ['System.Runtime']'System'.'AttributeUsageAttribute'::.ctor(valuetype ['System.Runtime']'System'.'AttributeTargets') = ( 01 00 02 00 00 00 02 00 54 02 0D 41 6C 6C 6F 77   // ........T..Allow
                                                                                                                                                 4D 75 6C 74 69 70 6C 65 00 54 02 09 49 6E 68 65   // Multiple.T..Inhe
                                                                                                                                                 72 69 74 65 64 00 )                               // rited.
  .field public initonly int32 'Version'
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(int32 'A_1') cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void ['System.Runtime']'System'.'Attribute'::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      int32 'System.Runtime.CompilerServices'.'RefSafetyRulesAttribute'::'Version'
    IL_000e:  ret
  } // end of method 'RefSafetyRulesAttribute'::.ctor

} // end of class 'System.Runtime.CompilerServices'.'RefSafetyRulesAttribute'

.class public abstract auto ansi sealed beforefieldinit 'CodeInject'.'GameMethods'
       extends ['System.Runtime']'System'.'Object'
{
  .class auto ansi sealed nested public 'SendFunc'
         extends ['System.Runtime']'System'.'MulticastDelegate'
  {
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(object 'object',
                                 native int 'method') runtime managed
    {
    } // end of method 'SendFunc'::.ctor

    .method public hidebysig newslot virtual 
            instance void  'Invoke'(native int 'a',
                                    int16* 'packet') runtime managed
    {
    } // end of method 'SendFunc'::'Invoke'

    .method public hidebysig newslot virtual 
            instance class ['System.Runtime']'System'.'IAsyncResult' 
            'BeginInvoke'(native int 'a',
                          int16* 'packet',
                          class ['System.Runtime']'System'.'AsyncCallback' 'callback',
                          object 'object') runtime managed
    {
    } // end of method 'SendFunc'::'BeginInvoke'

    .method public hidebysig newslot virtual 
            instance void  'EndInvoke'(class ['System.Runtime']'System'.'IAsyncResult' 'result') runtime managed
    {
    } // end of method 'SendFunc'::'EndInvoke'

  } // end of class 'SendFunc'

  .method public hidebysig static pinvokeimpl("ClrBootstrap.dll" winapi) 
          int32  'AttackTarget'(uint32 'skill',
                                uint32 'monsterIndex') cil managed preservesig
  {
  }
  .method public hidebysig static pinvokeimpl("ClrBootstrap.dll" winapi) 
          uint64  'GetBaseAdress'() cil managed preservesig
  {
  }
  .method public hidebysig static pinvokeimpl("ClrBootstrap.dll" winapi) 
          uint64  'GetInt64'(uint64 'Adress') cil managed preservesig
  {
  }
  .method public hidebysig static pinvokeimpl("ClrBootstrap.dll" winapi) 
          int32  'GetInt32'(uint64 'Adress') cil managed preservesig
  {
  }
  .method public hidebysig static pinvokeimpl("ClrBootstrap.dll" winapi) 
          float32  'GetFloat'(uint64 'Adress') cil managed preservesig
  {
  }
  .method public hidebysig static pinvokeimpl("ClrBootstrap.dll" winapi) 
          int32  'SendPacketToServer'(uint64 'deviceAddr',
                                      uint8[] 'packet') cil managed preservesig
  {
    .custom instance void 'System.Runtime.CompilerServices'.'NullableContextAttribute'::.ctor(uint8) = ( 01 00 01 00 00 ) 
  }
  .method public hidebysig static uint64 
          'GetInt64'(uint64 'Adress',
                     int16[] 'offsets') cil managed
  {
    .custom instance void 'System.Runtime.CompilerServices'.'NullableContextAttribute'::.ctor(uint8) = ( 01 00 01 00 00 ) 
    // Code size       44 (0x2c)
    .maxstack  2
    .locals init (uint64 V_0,
             int16[] V_1,
             int32 V_2,
             int16 V_3,
             uint64 V_4)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  stloc.0
    IL_0003:  nop
    IL_0004:  ldarg.1
    IL_0005:  stloc.1
    IL_0006:  ldc.i4.0
    IL_0007:  stloc.2
    IL_0008:  br.s       IL_001e

    IL_000a:  ldloc.1
    IL_000b:  ldloc.2
    IL_000c:  ldelem.i2
    IL_000d:  stloc.3
    IL_000e:  nop
    IL_000f:  ldloc.0
    IL_0010:  call       uint64 'CodeInject'.'GameMethods'::'GetInt64'(uint64)
    IL_0015:  ldloc.3
    IL_0016:  conv.i8
    IL_0017:  add
    IL_0018:  stloc.0
    IL_0019:  nop
    IL_001a:  ldloc.2
    IL_001b:  ldc.i4.1
    IL_001c:  add
    IL_001d:  stloc.2
    IL_001e:  ldloc.2
    IL_001f:  ldloc.1
    IL_0020:  ldlen
    IL_0021:  conv.i4
    IL_0022:  blt.s      IL_000a

    IL_0024:  ldloc.0
    IL_0025:  stloc.s    V_4
    IL_0027:  br.s       IL_0029

    IL_0029:  ldloc.s    V_4
    IL_002b:  ret
  } // end of method 'GameMethods'::'GetInt64'

  .method public hidebysig static void  'SendPacketToServer'(int16* 'packet') cil managed
  {
    // Code size       84 (0x54)
    .maxstack  3
    .locals init (class 'CodeInject'.'GameMethods'/'SendFunc' V_0)
    IL_0000:  nop
    IL_0001:  call       uint64 'CodeInject'.'GameMethods'::'GetBaseAdress'()
    IL_0006:  ldc.i4     0x268dc
    IL_000b:  conv.i8
    IL_000c:  add
    IL_000d:  newobj     instance void ['System.Runtime']'System'.'IntPtr'::.ctor(int64)
    IL_0012:  ldtoken    'CodeInject'.'GameMethods'/'SendFunc'
    IL_0017:  call       class ['System.Runtime']'System'.'Type' ['System.Runtime']'System'.'Type'::'GetTypeFromHandle'(valuetype ['System.Runtime']'System'.'RuntimeTypeHandle')
    IL_001c:  call       class ['System.Runtime']'System'.'Delegate' ['System.Runtime.InteropServices']'System.Runtime.InteropServices'.'Marshal'::'GetDelegateForFunctionPointer'(native int,
                                                                                                                                                                                   class ['System.Runtime']'System'.'Type')
    IL_0021:  castclass  'CodeInject'.'GameMethods'/'SendFunc'
    IL_0026:  stloc.0
    IL_0027:  ldloc.0
    IL_0028:  call       uint64 'CodeInject'.'GameMethods'::'GetBaseAdress'()
    IL_002d:  ldc.i4     0x1126948
    IL_0032:  conv.i8
    IL_0033:  add
    IL_0034:  call       uint64 'CodeInject'.'GameMethods'::'GetInt64'(uint64)
    IL_0039:  ldc.i4     0x16d8
    IL_003e:  conv.i8
    IL_003f:  add
    IL_0040:  ldc.i4     0x320
    IL_0045:  conv.i8
    IL_0046:  add
    IL_0047:  newobj     instance void ['System.Runtime']'System'.'IntPtr'::.ctor(int64)
    IL_004c:  ldarg.0
    IL_004d:  callvirt   instance void 'CodeInject'.'GameMethods'/'SendFunc'::'Invoke'(native int,
                                                                                       int16*)
    IL_0052:  nop
    IL_0053:  ret
  } // end of method 'GameMethods'::'SendPacketToServer'

} // end of class 'CodeInject'.'GameMethods'

.class public auto ansi beforefieldinit 'RoseHackDLL'.'Class1'
       extends ['System.Runtime']'System'.'Object'
{
.method private hidebysig static pinvokeimpl("kernel32" winapi) bool  'AllocConsole'() cil managed preservesig
  {
  }
.method public hidebysig static void modopt(['mscorlib']'System.Runtime.CompilerServices.CallConvCdecl')  'IMain'(string 'msg')
  {
    .custom instance void 'System.Runtime.CompilerServices'.'NullableContextAttribute'::.ctor(uint8) = ( 01 00 01 00 00 ) 
    .export [1] as 'IMain'
    .maxstack  1
    .locals init (uint64 V_0)
    IL_0000:  nop
    IL_0001:  call       uint64 'CodeInject'.'GameMethods'::'GetBaseAdress'()
    IL_0006:  stloc.0
    IL_0007:  ldloca.s   V_0
    IL_0009:  call       instance string ['System.Runtime']'System'.'UInt64'::'ToString'()
    IL_000e:  call       valuetype ['System.Windows.Forms']'System.Windows.Forms'.'DialogResult' ['System.Windows.Forms']'System.Windows.Forms'.'MessageBox'::'Show'(string)
    IL_0013:  pop
    IL_0014:  ret
  } // end of method 'Class1'::'IMain'

.method public hidebysig specialname rtspecialname instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void ['System.Runtime']'System'.'Object'::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method 'Class1'::.ctor

} // end of class 'RoseHackDLL'.'Class1'


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file C:\Users\grzeg\AppData\Local\Temp\dxp-6a28a828-4ea1-4ebc-8d84-2bea5e6ff38f\RoseHackDLL.res

