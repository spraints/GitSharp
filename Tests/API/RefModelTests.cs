/*
 * Copyright (C) 2009, Henon <meinrad.recheis@gmail.com>
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
using System.Linq;
using System.Text;
using NUnit.Framework;
using Git;
using GitSharp.Tests;

namespace Git.Tests
{
    [TestFixture]
    public class RefModelTests : RepositoryTestCase
    {

        [Test]
        public void UpdateBranch()
        {
            var repo = new Repository(db);
            var master = new Branch(repo, "refs/heads/master");
            var origin_master = new Branch(repo, "refs/remotes/origin/master");
            origin_master.Update(master);
            Assert.AreEqual(master.CurrentCommit.Hash, origin_master.CurrentCommit.Hash);
            var remote_head = repo.Refs["refs/remotes/origin/master"];
            Assert.AreEqual(master.CurrentCommit.Hash, remote_head.Target.Hash);
        }

        [Test]
        public void RefNameResolution()
        {
            var repo = new Repository(db);
            var master = new Ref(repo, "refs/heads/master");
            var previous = new Ref(repo,"refs/heads/master^");
            Assert.AreNotEqual(master.Target.Hash, previous.Target.Hash);
            Assert.AreEqual((master.Target as Commit).Parent.Hash, previous.Target.Hash);
        }

        [Test]
        public void RefEquality()
        {
            var repo = new Repository(db);
            Assert.IsTrue(new Ref(repo, "a") == new Ref(repo, "refs/heads/a"));
            Assert.IsTrue(new Ref(repo, "HEAD") == new Ref(repo, "refs/heads/master"));
        }
    }
}