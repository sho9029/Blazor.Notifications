﻿using System;

namespace Append.Blazor.Notifications
{
    /// <summary>
    /// A notification is an abstract representation of something that happened, such as the delivery of a message.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Defines a title for the notification, which will be shown at the top of the notification window when it is fired.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; private set; }

        /// <summary>
        /// A <see cref="DateTime"/> representing the time, in milliseconds since 00:00:00 UTC on 1 January 1970, of the event for which the notification was created.
        /// </summary>
        public DateTime? TimeStamp { get; private set; } = DateTime.UtcNow;
        /// <summary>
        /// The direction in which to display the notification. It defaults to auto, which just adopts the browser's language setting behavior, but you can override that behaviour by setting values of ltr and rtl (although most browsers seem to ignore these settings.)
        /// </summary>
        public string Dir { get; private set; }
        /// <summary>
        /// The notification's language, as specified using a DOMString representing a BCP 47 language tag. See the Sitepoint ISO 2 letter language codes page for a simple reference.
        /// </summary>
        public string Lang { get; private set; }
        /// <summary>
        /// An array of <see cref="NotificationAction"/>s representing the actions available to the user when the notification is presented.
        /// These are options the user can choose among in order to act on the action within the context of the notification itself.
        /// The action's name is sent to the service worker notification handler to let it know the action was selected by the user.
        /// </summary>
        public NotificationAction[] Actions { get; private set; }
        /// <summary>
        /// a <see cref="string"/> containing the URL of the image used to represent the notification when there is not enough space to display the notification itself.
        /// </summary>
        public string Badge { get; private set; }
        /// <summary>
        /// A <see cref="string"/> representing the body text of the notification, which will be displayed below the title.
        /// </summary>
        public string Body { get; private set; }
        /// <summary>
        /// A <see cref="string"/> representing an identifying tag for the notification.
        /// </summary>
        public string Tag { get; private set; }
        /// <summary>
        /// A <see cref="string"/> containing the URL of an icon to be displayed in the notification.
        /// </summary>
        public string Icon { get; private set; }
        /// <summary>
        /// A <see cref="string"/> containing the URL of an image to be displayed in the notification.
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// An <see cref="object"/> with arbitrary data that you want associated with the notification. This can be of any data type.
        /// </summary>
        public object Data { get; private set; }
        public bool? Renotify { get; private set; }
        /// <summary>
        /// Indicates that a notification should remain active until the user clicks or dismisses it, rather than closing automatically. The default value is false.
        /// </summary>
        public bool? RequireInteraction { get; private set; }
        public bool? Silent { get; private set; }
        /// <summary>
        /// A <see cref="string"/> containing the URL of an audio file to be played when the notification fires.
        /// </summary>
        public string Sound { get; private set; }
        /// <summary>
        /// noscreen: A Boolean specifying whether the notification firing should enable the device's screen or not.
        /// The default is false, which means it will enable the screen.
        /// </summary>
        public bool? NoScreen { get; private set; }
        /// <summary>
        /// sticky: A Boolean specifying whether the notification should be 'sticky', i.e. not easily clearable by the user.
        /// The default is false, which means it won't be sticky.
        /// </summary>
        public bool? Sticky { get; private set; }
        /// <summary>
        /// The amount of seconds until the notifciation is closed. Default is 5 seconds
        /// </summary>
        public int TimeOut { get; private set; } = 5;

        public Notification(string title, NotificationOptions options = null)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException($"{nameof(title)}, cannot be null or empty.");

            Title = title;

            if (options == null)
                return;

            TimeStamp = options.TimeStamp;
            Dir = options.Dir;
            Lang = options.Lang;
            Actions = options.Actions;
            Badge = options.Badge;
            Body = options.Body; ;
            Tag = options.Tag;
            Icon = options.Icon;
            Image = options.Image;
            Data = options.Data;
            Renotify = options.Renotify;
            RequireInteraction = options.RequireInteraction;
            Silent = options.Silent;
            Sound = options.Sound;
            NoScreen = options.NoScreen;
            Sticky = options.Sticky;
            TimeOut = options.TimeOut ?? TimeOut;
        }
    }
}
