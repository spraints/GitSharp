﻿/*
 * Copyright (C) 2008, Robin Rosenberg <robin.rosenberg@dewire.com>
 * Copyright (C) 2008, Shawn O. Pearce <spearce@spearce.org>
 * Copyright (C) 2008, Kevin Thompson <kevin.thompson@theautomaters.com>
 *
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or
 * without modification, are permitted provided that the following
 * conditions are met:
 *
 * - Redistributions of source code must retain the above copyright
 *   notice, this list of conditions and the following disclaimer.
 *
 * - Redistributions in binary form must reproduce the above
 *   copyright notice, this list of conditions and the following
 *   disclaimer in the documentation and/or other materials provided
 *   with the distribution.
 *
 * - Neither the name of the Git Development Community nor the
 *   names of its contributors may be used to endorse or promote
 *   products derived from this software without specific prior
 *   written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
 * CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 * STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.Text;
using GitSharp.Util;

namespace GitSharp
{
	public class ObjectId : AnyObjectId
	{
		private static readonly string ZeroIdString;

		static ObjectId()
		{
			ZeroId = new ObjectId(0, 0, 0, 0, 0);
			ZeroIdString = ZeroId.ToString();
		}

		internal ObjectId(int w1, int w2, int w3, int w4, int w5)
		{
			W1 = w1;
			W2 = w2;
			W3 = w3;
			W4 = w4;
			W5 = w5;
		}

		public ObjectId(AnyObjectId src)
		{
			W1 = src.W1;
			W2 = src.W2;
			W3 = src.W3;
			W4 = src.W4;
			W5 = src.W5;
		}

		public static ObjectId ZeroId { get; private set; }

		public static bool IsId(string id)
		{
			if (id.Length != 2 * ObjectIdLength)
			{
				return false;
			}

			try
			{
				for (int k = id.Length - 1; k >= 0; k--)
				{
					if (Hex.HexCharToValue(id[k]) == byte.MaxValue) return false;
				}

				return true;
			}
			catch (IndexOutOfRangeException)
			{
				return false;
			}
		}

		public static string ToString(ObjectId i)
		{
			return i != null ? i.ToString() : ZeroIdString;
		}

		/// <summary>
		/// Compare to object identifier byte sequences for equality.
		/// </summary>
		/// <param name="firstBuffer">
		/// the first buffer to compare against. Must have at least 20
		/// bytes from position ai through the end of the buffer.
		/// </param>
		/// <param name="fi">
		/// first offset within firstBuffer to begin testing.
		/// </param>
		/// <param name="secondBuffer">
		/// the second buffer to compare against. Must have at least 2
		/// bytes from position bi through the end of the buffer.
		/// </param>
		/// <param name="si">
		/// first offset within secondBuffer to begin testing.
		/// </param>
		/// <returns>
		/// return true if the two identifiers are the same.
		/// </returns>
		public static bool Equals(byte[] firstBuffer, int fi, byte[] secondBuffer, int si)
		{
			return firstBuffer[fi] == secondBuffer[si]
			       && firstBuffer[fi + 1] == secondBuffer[si + 1]
			       && firstBuffer[fi + 2] == secondBuffer[si + 2]
			       && firstBuffer[fi + 3] == secondBuffer[si + 3]
			       && firstBuffer[fi + 4] == secondBuffer[si + 4]
			       && firstBuffer[fi + 5] == secondBuffer[si + 5]
			       && firstBuffer[fi + 6] == secondBuffer[si + 6]
			       && firstBuffer[fi + 7] == secondBuffer[si + 7]
			       && firstBuffer[fi + 8] == secondBuffer[si + 8]
			       && firstBuffer[fi + 9] == secondBuffer[si + 9]
			       && firstBuffer[fi + 10] == secondBuffer[si + 10]
			       && firstBuffer[fi + 11] == secondBuffer[si + 11]
			       && firstBuffer[fi + 12] == secondBuffer[si + 12]
			       && firstBuffer[fi + 13] == secondBuffer[si + 13]
			       && firstBuffer[fi + 14] == secondBuffer[si + 14]
			       && firstBuffer[fi + 15] == secondBuffer[si + 15]
			       && firstBuffer[fi + 16] == secondBuffer[si + 16]
			       && firstBuffer[fi + 17] == secondBuffer[si + 17]
			       && firstBuffer[fi + 18] == secondBuffer[si + 18]
			       && firstBuffer[fi + 19] == secondBuffer[si + 19];
		}

		public static ObjectId FromString(byte[] bs, int offset)
		{
			return FromHexString(bs, offset);
		}

		public static ObjectId FromString(string s)
		{
			if (string.IsNullOrEmpty(s) || s.Length != StringLength) return null;
			return FromHexString(Constants.encodeASCII(s), 0);
		}

		public static ObjectId FromHexString(byte[] bs, int offset)
		{
			try
			{
				int a = Hex.HexStringToUInt32(bs, offset);
				int b = Hex.HexStringToUInt32(bs, offset + 8);
				int c = Hex.HexStringToUInt32(bs, offset + 16);
				int d = Hex.HexStringToUInt32(bs, offset + 24);
				int e = Hex.HexStringToUInt32(bs, offset + 32);
				return new ObjectId(a, b, c, d, e);
			}
			catch (IndexOutOfRangeException)
			{
				var s = new string(Encoding.ASCII.GetChars(bs, offset, StringLength));
				throw new ArgumentException("Invalid id: " + s, "bs");
			}
		}

		public override ObjectId ToObjectId()
		{
			return this;
		}

		public static ObjectId FromRaw(byte[] buffer)
		{
			return FromRaw(buffer, 0);
		}

		public static ObjectId FromRaw(byte[] buffer, int offset)
		{
			int a = NB.DecodeInt32(buffer, offset);
			int b = NB.DecodeInt32(buffer, offset + 4);
			int c = NB.DecodeInt32(buffer, offset + 8);
			int d = NB.DecodeInt32(buffer, offset + 12);
			int e = NB.DecodeInt32(buffer, offset + 16);
			return new ObjectId(a, b, c, d, e);
		}

		public static ObjectId FromRaw(int[] intbuffer)
		{
			return FromRaw(intbuffer, 0);
		}

		public static ObjectId FromRaw(int[] intbuffer, int offset)
		{
			return new ObjectId(intbuffer[offset], intbuffer[offset + 1], intbuffer[offset + 2], intbuffer[offset + 3],
			                    intbuffer[offset + 4]);
		}
	}

	class ObjectIdEqualityComparer<T> : IEqualityComparer<T>
		where T : ObjectId
	{
		#region Implementation of IEqualityComparer<ObjectId>

		/// <summary>
		/// Determines whether the specified objects are equal.
		/// </summary>
		/// <returns>
		/// true if the specified objects are equal; otherwise, false.
		/// </returns>
		/// <param name="x">
		/// The first object of type <see cref="ObjectId"/> to compare.
		/// </param>
		/// <param name="y">
		/// The second object of type <see cref="ObjectId"/> to compare.
		/// </param>
		public bool Equals(T x, T y)
		{
			return x == y;
		}

		/// <summary>
		/// Returns a hash code for the specified object.
		/// </summary>
		/// <returns>
		/// A hash code for the specified object.
		/// </returns>
		/// <param name="obj">
		/// The <see cref="ObjectId"/> for which a hash code is to be returned.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.
		/// </exception>
		public int GetHashCode(T obj)
		{
			return obj.GetHashCode();
		}

		#endregion
	}
}