using System;
using System.IO;
using System.Messaging;

namespace windows_filesystemsynchronizer.FilesWatcher
{
    internal class MessageLoader
    {

        private const String privateQueuePath = ".\\Private$\\windows-filesystemwatcher-queue";

        private MessageQueue myQueue = null;

        public MessageLoader()
        {
            myQueue = new MessageQueue(privateQueuePath);
        }

        // References private queues.
        public void SendPrivate(FileSystemEventArgs e)
        {
            WatcherQueueMessage messageToQueue = new WatcherQueueMessage(e);
            myQueue.Send(messageToQueue.Serialized());
        }

    }

}
