using NUnit.Framework;
    [TestFixture]
        [Test]
			Assert.AreEqual(-1, fh.parseGitFileName(0, fh.Buffer.Length));
		    Assert.IsNotNull(fh.Hunks);
		    Assert.IsTrue(fh.Hunks.Count == 0);
		    Assert.IsFalse(fh.hasMetaDataChanges());
        [Test]
			Assert.AreEqual(-1, fh.parseGitFileName(0, fh.Buffer.Length));
        [Test]
			Assert.AreEqual(-1, fh.parseGitFileName(0, fh.Buffer.Length));
        [Test]
			Assert.AreEqual(1, fh.parseGitFileName(0, fh.Buffer.Length));
        [Test]
			Assert.AreEqual(GitLine(name).Length, fh.parseGitFileName(0, fh.Buffer.Length));
		    Assert.AreEqual(name, fh.OldName);
		    Assert.AreSame(fh.OldName, fh.NewName);
		    Assert.IsFalse(fh.hasMetaDataChanges());
        [Test]
			Assert.IsTrue(fh.parseGitFileName(0, fh.Buffer.Length) > 0);
		    Assert.IsNull(fh.OldName);
		    Assert.IsNull(fh.NewName);
		    Assert.IsFalse(fh.hasMetaDataChanges());
        [Test]
		    Assert.AreEqual(GitLine(name).Length, fh.parseGitFileName(0,
		    Assert.AreEqual(name, fh.OldName);
		    Assert.AreSame(fh.OldName, fh.NewName);
		    Assert.IsFalse(fh.hasMetaDataChanges());
        [Test]
		    Assert.AreEqual(DqGitLine(dqName).Length, fh.parseGitFileName(0,
		    Assert.AreEqual(name, fh.OldName);
		    Assert.AreSame(fh.OldName, fh.NewName);
		    Assert.IsFalse(fh.hasMetaDataChanges());
        [Test]
		    Assert.AreEqual(DqGitLine(dqName).Length, fh.parseGitFileName(0,
		    Assert.AreEqual(name, fh.OldName);
		    Assert.AreSame(fh.OldName, fh.NewName);
		    Assert.IsFalse(fh.hasMetaDataChanges());
        [Test]
		    Assert.AreEqual(GitLine(name).Length, fh.parseGitFileName(0,
		    Assert.AreEqual(name, fh.OldName);
		    Assert.AreSame(fh.OldName, fh.NewName);
		    Assert.IsFalse(fh.hasMetaDataChanges());
        [Test]
			Assert.AreEqual(header.Length, fh.parseGitFileName(0, fh.Buffer.Length));
		    Assert.AreEqual(name, fh.OldName);
		    Assert.AreSame(fh.OldName, fh.NewName);
		    Assert.IsFalse(fh.hasMetaDataChanges());
        [Test]
		    Assert.AreEqual("/dev/null", fh.OldName);
		    Assert.AreSame(FileHeader.DEV_NULL, fh.OldName);
		    Assert.AreEqual("\u00c5ngstr\u00f6m", fh.NewName);
            Assert.AreEqual(FileHeader.ChangeTypeEnum.ADD, fh.getChangeType());
            Assert.AreEqual(FileHeader.PatchTypeEnum.UNIFIED, fh.getPatchType());
		    Assert.IsTrue(fh.hasMetaDataChanges());
		    Assert.AreSame(FileMode.Missing, fh.GetOldMode());
		    Assert.AreSame(FileMode.RegularFile, fh.NewMode);
		    Assert.AreEqual("0000000", fh.getOldId().name());
		    Assert.AreEqual("7898192", fh.getNewId().name());
		    Assert.AreEqual(0, fh.getScore());
        [Test]
		    Assert.AreEqual("\u00c5ngstr\u00f6m", fh.OldName);
		    Assert.AreEqual("/dev/null", fh.NewName);
		    Assert.AreSame(FileHeader.DEV_NULL, fh.NewName);
            Assert.AreEqual(FileHeader.ChangeTypeEnum.DELETE, fh.getChangeType());
            Assert.AreEqual(FileHeader.PatchTypeEnum.UNIFIED, fh.getPatchType());
		    Assert.IsTrue(fh.hasMetaDataChanges());
		    Assert.AreSame(FileMode.RegularFile, fh.GetOldMode());
		    Assert.AreSame(FileMode.Missing, fh.NewMode);
		    Assert.AreEqual("7898192", fh.getOldId().name());
		    Assert.AreEqual("0000000", fh.getNewId().name());
		    Assert.AreEqual(0, fh.getScore());
        [Test]
		    Assert.AreEqual("a b", fh.OldName);
		    Assert.AreEqual("a b", fh.NewName);
		    Assert.AreEqual(FileHeader.ChangeTypeEnum.MODIFY, fh.getChangeType());
            Assert.AreEqual(FileHeader.PatchTypeEnum.UNIFIED, fh.getPatchType());
		    Assert.IsTrue(fh.hasMetaDataChanges());
		    Assert.IsNull(fh.getOldId());
		    Assert.IsNull(fh.getNewId());
		    Assert.AreSame(FileMode.RegularFile, fh.GetOldMode());
		    Assert.AreSame(FileMode.ExecutableFile, fh.NewMode);
		    Assert.AreEqual(0, fh.getScore());
        [Test]
		    Assert.IsTrue(ptr > 0);
		    Assert.IsNull(fh.OldName); // can't parse names on a rename
		    Assert.IsNull(fh.NewName);
		    Assert.IsTrue(ptr > 0);
		    Assert.AreEqual("a", fh.OldName);
		    Assert.AreEqual(" c/\u00c5ngstr\u00f6m", fh.NewName);
		    Assert.AreEqual(FileHeader.ChangeTypeEnum.RENAME, fh.getChangeType());
            Assert.AreEqual(FileHeader.PatchTypeEnum.UNIFIED, fh.getPatchType());
		    Assert.IsTrue(fh.hasMetaDataChanges());
		    Assert.IsNull(fh.getOldId());
		    Assert.IsNull(fh.getNewId());
		    Assert.IsNull(fh.GetOldMode());
		    Assert.IsNull(fh.NewMode);
		    Assert.AreEqual(100, fh.getScore());
        [Test]
		    Assert.IsTrue(ptr > 0);
		    Assert.IsNull(fh.OldName); // can't parse names on a rename
		    Assert.IsNull(fh.NewName);
		    Assert.IsTrue(ptr > 0);
		    Assert.AreEqual("a", fh.OldName);
		    Assert.AreEqual(" c/\u00c5ngstr\u00f6m", fh.NewName);
            Assert.AreEqual(FileHeader.ChangeTypeEnum.RENAME, fh.getChangeType());
            Assert.AreEqual(FileHeader.PatchTypeEnum.UNIFIED, fh.getPatchType());
		    Assert.IsTrue(fh.hasMetaDataChanges());
		    Assert.IsNull(fh.getOldId());
		    Assert.IsNull(fh.getNewId());
		    Assert.IsNull(fh.GetOldMode());
		    Assert.IsNull(fh.NewMode);
		    Assert.AreEqual(100, fh.getScore());
        [Test]
		    Assert.IsTrue(ptr > 0);
		    Assert.IsNull(fh.OldName); // can't parse names on a copy
		    Assert.IsNull(fh.NewName);
		    Assert.IsTrue(ptr > 0);
		    Assert.AreEqual("a", fh.OldName);
		    Assert.AreEqual(" c/\u00c5ngstr\u00f6m", fh.NewName);
		    Assert.AreEqual(FileHeader.ChangeTypeEnum.COPY, fh.getChangeType());
		    Assert.AreEqual(FileHeader.PatchTypeEnum.UNIFIED, fh.getPatchType());
		    Assert.IsTrue(fh.hasMetaDataChanges());
		    Assert.IsNull(fh.getOldId());
		    Assert.IsNull(fh.getNewId());
		    Assert.IsNull(fh.GetOldMode());
		    Assert.IsNull(fh.NewMode);
		    Assert.AreEqual(100, fh.getScore());
        [Test]
		    Assert.AreEqual("a", fh.OldName);
		    Assert.AreEqual("a", fh.NewName);
		    Assert.AreSame(FileMode.RegularFile, fh.GetOldMode());
		    Assert.AreSame(FileMode.RegularFile, fh.NewMode);
		    Assert.IsFalse(fh.hasMetaDataChanges());
		    Assert.IsNotNull(fh.getOldId());
		    Assert.IsNotNull(fh.getNewId());
		    Assert.IsTrue(fh.getOldId().isComplete());
		    Assert.IsTrue(fh.getNewId().isComplete());
		    Assert.AreEqual(ObjectId.FromString(oid), fh.getOldId().ToObjectId());
		    Assert.AreEqual(ObjectId.FromString(nid), fh.getNewId().ToObjectId());
		    Assert.AreEqual("a", fh.OldName);
		    Assert.AreEqual("a", fh.NewName);
		    Assert.IsFalse(fh.hasMetaDataChanges());
		    Assert.IsNull(fh.GetOldMode());
		    Assert.IsNull(fh.NewMode);
		    Assert.IsNotNull(fh.getOldId());
		    Assert.IsNotNull(fh.getNewId());
		    Assert.IsTrue(fh.getOldId().isComplete());
		    Assert.IsTrue(fh.getNewId().isComplete());
		    Assert.AreEqual(ObjectId.FromString(oid), fh.getOldId().ToObjectId());
		    Assert.AreEqual(ObjectId.FromString(nid), fh.getNewId().ToObjectId());
        [Test]
		    Assert.AreEqual("a", fh.OldName);
		    Assert.AreEqual("a", fh.NewName);
		    Assert.AreSame(FileMode.RegularFile, fh.GetOldMode());
		    Assert.AreSame(FileMode.RegularFile, fh.NewMode);
		    Assert.IsFalse(fh.hasMetaDataChanges());
		    Assert.IsNotNull(fh.getOldId());
		    Assert.IsNotNull(fh.getNewId());
		    Assert.IsFalse(fh.getOldId().isComplete());
		    Assert.IsFalse(fh.getNewId().isComplete());
		    Assert.AreEqual(oid.Substring(0, a - 1), fh.getOldId().name());
		    Assert.AreEqual(nid.Substring(0, a - 1), fh.getNewId().name());
		    Assert.IsTrue(ObjectId.FromString(oid).startsWith(fh.getOldId()));
		    Assert.IsTrue(ObjectId.FromString(nid).startsWith(fh.getNewId()));
        [Test]
		    Assert.AreEqual("a", fh.OldName);
		    Assert.AreEqual("a", fh.NewName);
		    Assert.IsNull(fh.GetOldMode());
		    Assert.IsNull(fh.NewMode);
		    Assert.IsFalse(fh.hasMetaDataChanges());
		    Assert.IsNotNull(fh.getOldId());
		    Assert.IsNotNull(fh.getNewId());
		    Assert.IsFalse(fh.getOldId().isComplete());
		    Assert.IsFalse(fh.getNewId().isComplete());
		    Assert.AreEqual(oid.Substring(0, a - 1), fh.getOldId().name());
		    Assert.AreEqual(nid.Substring(0, a - 1), fh.getNewId().name());
		    Assert.IsTrue(ObjectId.FromString(oid).startsWith(fh.getOldId()));
		    Assert.IsTrue(ObjectId.FromString(nid).startsWith(fh.getNewId()));
		    Assert.IsTrue(ptr > 0);
		    Assert.IsTrue(ptr > 0);