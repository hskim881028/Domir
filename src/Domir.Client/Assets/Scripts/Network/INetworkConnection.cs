﻿using System;
using MagicOnion;

namespace Domir.Client.Network
{
    public interface INetworkConnection : IResponseHandler
    {
        public void Connect();
        public Lazy<T> CreateService<T>() where T : IService<T>;
    }
}