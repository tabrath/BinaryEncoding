# BinaryEncoding

[![Travis](https://img.shields.io/travis/tabrath/BinaryEncoding.svg?longCache=true&style=flat-square&label=Travis&logo=travis)](https://travis-ci.org/tabrath/BinaryEncoding)
[![Appveyor](https://img.shields.io/appveyor/ci/tabrath/BinaryEncoding.svg?longCache=true&style=flat-square&label=Appveyor&logo=appveyor)](https://ci.appveyor.com/project/tabrath/binaryencoding/branch/master)
[![CircleCI](https://img.shields.io/circleci/project/github/tabrath/BinaryEncoding.svg?longCache=true&style=flat-square&label=CircleCI)](https://circleci.com/gh/tabrath/BinaryEncoding)
[![Codecov](https://img.shields.io/codecov/c/github/tabrath/BinaryEncoding.svg?longCache=true&style=flat-square&label=Codecov)](https://codecov.io/gh/tabrath/BinaryEncoding)
[![Version](https://img.shields.io/nuget/v/BinaryEncoding.svg?longCache=true&style=flat-square&label=Version)](https://www.nuget.org/packages/BinaryEncoding)
[![Downloads](https://img.shields.io/nuget/dt/BinaryEncoding.svg?longCache=true&style=flat-square&label=Downloads)](https://www.nuget.org/packages/BinaryEncoding)
[![Forks](https://img.shields.io/github/forks/tabrath/BinaryEncoding.svg?longCache=true&style=flat-square&label=Forks&logo=github)](https://github.com/tabrath/BinaryEncoding/fork)
[![Stars](https://img.shields.io/github/stars/tabrath/BinaryEncoding.svg?longCache=true&style=flat-square&label=Stars&logo=github)](https://github.com/tabrath/BinaryEncoding/star)
[![License](https://img.shields.io/github/license/tabrath/BinaryEncoding.svg?longCache=true&style=flat-square&label=License)](https://github.com/tabrath/BinaryEncoding/blob/master/LICENSE)
![Frameworks](https://img.shields.io/badge/frameworks-netstandard1.1%20|%20net%20v4.5.2-green.svg?longCache=true&style=flat-square)
![Platforms](https://img.shields.io/badge/platforms-win%20|%20linux%20|%20osx-green.svg?longCache=true&style=flat-square)

BinaryEncoding simplifies the encoding of numbers to BigEndian, LittleEndian and Varint to byte arrays.

## API

To set values to an array of bytes:
``` cs
Binary.BigEndian.Set(bytes, offset, value);
Binary.LittleEndian.Set(bytes, offset, value);
Binary.Varint.Write(bytes, offset, value);
```

Extension methods are provided for retrieving the bytes:
``` cs
Binary.BigEndian.GetBytes(value);
Binary.LittleEndian.GetBytes(value);
Binary.Varint.GetBytes(value);
```

Also, for converting bytes to numbers:
``` cs
Binary.BigEndian.GetInt16(bytes, offset);
Binary.BigEndian.GetInt32(bytes, offset);
Binary.BigEndian.GetInt64(bytes, offset);
Binary.BigEndian.GetUInt16(bytes, offset);
Binary.BigEndian.GetUInt32(bytes, offset);
Binary.BigEndian.GetUInt64(bytes, offset);
Binary.LittleEndian.GetInt16(bytes, offset);
Binary.LittleEndian.GetInt32(bytes, offset);
Binary.LittleEndian.GetInt64(bytes, offset);
Binary.LittleEndian.GetUInt16(bytes, offset);
Binary.LittleEndian.GetUInt32(bytes, offset);
Binary.LittleEndian.GetUInt64(bytes, offset);

// varint, returns number of bytes consumed
// value can be short, ushort, int, uint, long, ulong
Binary.Varint.Read(bytes, out value);
```

.. more to come
