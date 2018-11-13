using System.Net.Sockets;
using BenchmarkDotNet.Attributes;

namespace ImpactAnalyzer
{
    [MarkdownExporterAttribute.GitHub]
    public class Experiment
    {
        private Socket _socket;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        [Benchmark]
        public void DisableAddressSharing()
        {
            _socket.ExclusiveAddressUse = true;
        }

        [Benchmark]
        public void DontLinger()
        {
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
        }

        [Benchmark]
        public void Debug()
        {
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Debug, true);
        }

        [Benchmark]
        public void KeepAlive()
        {
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
        }

        [Benchmark]
        public void OutOfBandInline()
        {
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.OutOfBandInline, true);
        }

        [Benchmark]
        public void ReuseAddress()
        {
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        [Benchmark]
        public void BsdUrgent()
        {
            _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.BsdUrgent, true);
        }

        [Benchmark]
        public void Expedited()
        {
            _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Expedited, true);
        }

        [Benchmark]
        public void NoDelay()
        {
            _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
        }

        [Benchmark]
        public void ReceiveBuffer()
        {
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, 100);
        }

        [Benchmark]
        public void ReceiveTimeout()
        {
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 100);
        }

        [Benchmark]
        public void SendBuffer()
        {
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, 100);
        }

        [Benchmark]
        public void SendTimeout()
        {
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 100);
        }

        [Benchmark]
        public void IPOptions()
        {
            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.IPOptions, 1);
        }

        [Benchmark]
        public void IpTimeToLive()
        {
            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.IpTimeToLive, 100);
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _socket.Dispose();
        }
    }
}