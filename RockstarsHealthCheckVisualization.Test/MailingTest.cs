﻿using RockstarsHealthCheckVisualization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RockstarsHealthCheckVisualization.Test;

public class MailingTest
{
    [Fact]
    public void IsListLoaded()
    {
        MailingViewModel mailingViewModel = new MailingViewModel();
        mailingViewModel.FillSelectQuestionnaireList();

        Assert.True(mailingViewModel.GetList().Count >= 1);
    }
}