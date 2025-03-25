using System;
using System.Runtime.InteropServices;

namespace ClrDebug.TTD
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct SystemInfo //456 bytes?
    {
        public int _unknown1; //0
        public int _unknown2; //4
        public int _unknown3; //8
        public int _unknown4; //12
        public long _unknown5; //16
        public long _unknown6; //24
        public int _unknown7; //32
        public int _unknown8; //36
        public int _unknown9; //40
        public int _unknown10; //44
        public int _unknown11; //48
        public int _unknown12; //52
        public int _unknown13; //56
        public int _unknown14; //60
        public int _unknown15; //64
        public int _unknown16; //68
        public int _unknown17; //72
        public int _unknown18; //76
        public int _unknown19; //80
        public int _unknown20; //84

        //manufacturerid? x86 only?
        public int _unknown21; //88
        public int _unknown22; //92
        public int _unknown23; //96

        public int _unknown24; //100
        public int _unknown25; //104
        public int _unknown26; //108

        public fixed short wszUserName[64]; //112
        public fixed short wszComputerName[64]; //240

        public int _unknown29; //368
        public int _unknown30; //372
        public int _unknown31; //376
        public int _unknown32; //380

        public long _unknown33; //384
        public IntPtr _unknownVtbl1; //392 TTDReplay!std::_Func_impl_no_alloc<std::unique_ptr<TTD::Replay::ExecutionState,TTD::Replay::ExecutionStateDeleter> (__cdecl*)(enum TTD::Replay::UniqueThreadId,enum TTD::Replay::SegmentIndex,TTD::ContextBoundCallback<void __cdecl(unsigned __int64,TTD::TBufferView<1>,TTD::Replay::IThreadView const * __ptr64)>),std::unique_ptr<TTD::Replay::ExecutionState,TTD::Replay::ExecutionStateDeleter>,enum TTD::Replay::UniqueThreadId,enum TTD::Replay::SegmentIndex,TTD::ContextBoundCallback<void __cdecl(unsigned __int64,TTD::TBufferView<1>,TTD::Replay::IThreadView const * __ptr64)> >::`vftable':
        public IntPtr _getEmptyExecutionState; //400 //TTDReplay!TTD::Replay::GetEmptyExecutionState

        public int _unknown36; //408
        public int _unknown37; //412
        public int _unknown38; //416
        public int _unknown39; //420
        public int _unknown40; //424
        public int _unknown41; //428
        public int _unknown42; //432
        public int _unknown43; //436
        public int _unknown44; //440
        public int _unknown45; //444

        public IntPtr _unknown46; //448

        public string UserName
        {
            get
            {
                fixed (short* p = wszUserName)
                    return Marshal.PtrToStringUni((IntPtr) p);
            }
        }

        public string ComputerName
        {
            get
            {
                fixed (short* p = wszComputerName)
                    return Marshal.PtrToStringUni((IntPtr) p);
            }
        }
    }
}
