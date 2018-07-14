﻿#region Copyright 2008-2012 by Roger Knapp, Licensed under the Apache License, Version 2.0
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
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel;

#pragma warning disable 1591

namespace CSharpTest.Net.CSBuild.Configuration
{
    [Serializable]
	public class BaseFileItem //: IFilePathInfo
	{
		string _path;
		OutputRelative _rel = OutputRelative.RelativeCSBuildExe;

		[XmlAttribute("relative-to")]
		[DefaultValue(OutputRelative.RelativeCSBuildExe)]
		public OutputRelative RelativeTo { get { return _rel; } set { _rel = value; } }

		[XmlAttribute("path")]
		public String Path { get { return _path; } set { _path = value; } }

		public virtual string AbsolutePath(IDictionary<string, string> namedValues)
		{ return Util.MakeAbsolutePath(_rel, _path, namedValues); }
	}
}
