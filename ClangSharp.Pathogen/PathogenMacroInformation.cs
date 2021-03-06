﻿using ClangSharp.Interop;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClangSharp.Pathogen
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct PathogenMacroInformation
    {
        private readonly byte* _Name;
        private readonly ulong _NameLength;
        public readonly CXSourceLocation Location;
        private readonly byte _WasUndefined;
        private readonly byte _IsFunctionLike;
        private readonly byte _IsBuiltinMacro;
        private readonly byte _HasCommaPasting;
        public readonly PathogenMacroVardicKind VardicKind;
        public readonly int ParameterCount;
        private readonly byte** ParameterNames;
        private readonly ulong* ParameterNameLengths;

        public string Name => Encoding.UTF8.GetString(_Name, checked((int)_NameLength));
        public bool WasUndefined => _WasUndefined != 0;
        public bool IsFunctionLike => _IsFunctionLike != 0;
        public bool IsBuiltinMacro => _IsBuiltinMacro != 0;
        public bool HasCommaPasting => _HasCommaPasting != 0;

        public string GetParameterName(int index)
        {
            if (index < 0 || index >= ParameterCount)
            { throw new ArgumentOutOfRangeException(nameof(index)); }

            return Encoding.UTF8.GetString(ParameterNames[index], checked((int)ParameterNameLengths[index]));
        }
    }
}
