using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Test;

public class URLTest
{
    [Fact]
    public void IsALinkGenerated()
    {
        Assert.False(string.IsNullOrEmpty(URL.GenerateQuestionnaireURL(1)));
    }

    [Fact]
    public void IsTheCorrectUrlSend()
    {
        string url = URL.GenerateQuestionnaireURL(1);

        Assert.Equal("https://rockstarshealthcheck.azurewebsites.net/Questionaire/index/1", url);
    }
}
