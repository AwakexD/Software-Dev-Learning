﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Models
{
    public class CreateCommitModel
    {
        public string UserId { get; set; }
        public string RepositoryId { get; set; }
        public string RepositoryName { get; set; }
        public string Description { get; set; }

    }
}
