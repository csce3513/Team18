﻿#region CPL License
/*
Nuclex Framework
Copyright (C) 2002-2009 Nuclex Development Labs

This library is free software; you can redistribute it and/or
modify it under the terms of the IBM Common Public License as
published by the IBM Corporation; either version 1.0 of the
License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
IBM Common Public License for more details.

You should have received a copy of the IBM Common Public
License along with this library
*/
#endregion

using System;

namespace Nuclex.Testing.Xna {

  /// <summary>Specifies the type of device driver.</summary>
  public enum DeviceType {

    /// <summary>
    ///   A hardware device. Using the flag to get direct access to the video hardware.
    /// </summary>
    Hardware,
    /// <summary>
    ///   A null device. This is a reference device that can do everything except render a scene.
    /// </summary>
    NullReference,
    /// <summary>
    ///   A reference device. Use this flag to create a software emulated device.
    /// </summary>
    Reference

  }

} // namespace Nuclex.Testing.Xna
