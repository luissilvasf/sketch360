﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Sketch360.XPlat.Interfaces
{
    public interface IExportImageCommand : System.Windows.Input.ICommand
    {
        Xamarin.Forms.Page Page { get; set; }
    }
}
