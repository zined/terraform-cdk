// DOCS_BLOCK_START:unit-tests
using Xunit;
using HashiCorp.Cdktf; // MyApplicationsAbstraction - Could be a class extending from Construct
using System;
using System.Collections.Generic;
using docker.Image;
using docker.Container;
using MyCompany.ApplicationsAbstraction;

namespace MyCompany.MyApp{
  public class TestApplication{

    private static TerraformStack stack = new TerraformStack(Testing.App(), "stack");
    private static MyApplicationsAbstraction appAbstraction = new MyApplicationsAbstraction(stack, "resource");
    private static string synthesized = Testing.Synth(stack);

    [Fact]
    public void ShouldContainContainer(){
      Assert.True(Testing.ToHaveResource(synthesized, Container.TfResourceType) );
    }

    [Fact]
    public void shouldUseUbuntuImage(){
      Assert.True(Testing.ToHaveResourceWithProperties(synthesized, Image.TfResourceType, new Dictionary<String, Object>() {
              {"name", "ubuntu:latest"}
      }) );
    }
  }
}
// DOCS_BLOCK_END:unit-tests