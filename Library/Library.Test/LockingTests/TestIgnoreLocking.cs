﻿#region Copyright 2011-2012 by Roger Knapp, Licensed under the Apache License, Version 2.0
/* Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion
using CSharpTest.Net.Synchronization;
using NUnit.Framework;

namespace CSharpTest.Net.Library.Test.LockingTests
{
    [TestFixture]
    public class TestIgnoreLocking : BaseLockTest<IgnoreLockFactory>
    {
        [Test]
        public void NoWriteIncrement()
        {
            using (ILockStrategy l = LockFactory.Create())
            {
                Assert.AreEqual(0, l.WriteVersion);
                using(l.Write())
                    Assert.AreEqual(0, l.WriteVersion);
                Assert.AreEqual(0, l.WriteVersion);
            }
        }
    }
    [TestFixture]
    public class TestIgnoreLockingDebug : BaseLockTest<DebugLockFactory<IgnoreLocking>>
    {
    }
    [TestFixture]
    public class TestIgnoreLockingCounts : BaseLockTest<LockCounterFactory<IgnoreLocking>>
    {
    }
}