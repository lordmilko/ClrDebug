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
        
        public TtdProcessorKind ProcessorKind; //56

        public short _unknown14; //58
        public int _unknown15; //60
        public int _unknown16; //64
        public int _unknown17; //68
        public int OSBuild; //72 e.g. what you see in winver. 
        public int _unknown19; //76
        public int _unknown20; //80
        public int _unknown21; //84

        //manufacturerid? x86 only?
        public int _unknown22; //88
        public int _unknown23; //92
        public int _unknown24; //96

        public int _unknown25; //100
        public int _unknown26; //104
        public int _unknown27; //108

        public fixed short wszUserName[64]; //112
        public fixed short wszComputerName[64]; //240

        public int _unknown30; //368
        public int _unknown31; //372
        public int _unknown32; //376
        public int _unknown33; //380

        public long _unknown34; //384
        public IntPtr _unknownVtbl1; //392 TTDReplay!std::_Func_impl_no_alloc<std::unique_ptr<TTD::Replay::ExecutionState,TTD::Replay::ExecutionStateDeleter> (__cdecl*)(enum TTD::Replay::UniqueThreadId,enum TTD::Replay::SegmentIndex,TTD::ContextBoundCallback<void __cdecl(unsigned __int64,TTD::TBufferView<1>,TTD::Replay::IThreadView const * __ptr64)>),std::unique_ptr<TTD::Replay::ExecutionState,TTD::Replay::ExecutionStateDeleter>,enum TTD::Replay::UniqueThreadId,enum TTD::Replay::SegmentIndex,TTD::ContextBoundCallback<void __cdecl(unsigned __int64,TTD::TBufferView<1>,TTD::Replay::IThreadView const * __ptr64)> >::`vftable':
        public IntPtr _getEmptyExecutionState; //400 //TTDReplay!TTD::Replay::GetEmptyExecutionState

        public int _unknown37; //408
        public int _unknown38; //412
        public int _unknown39; //416
        public int _unknown40; //420
        public int _unknown41; //424
        public int _unknown42; //428
        public int _unknown43; //432
        public int _unknown44; //436
        public int _unknown45; //440
        public int _unknown46; //444

        public IntPtr _unknown47; //448

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
