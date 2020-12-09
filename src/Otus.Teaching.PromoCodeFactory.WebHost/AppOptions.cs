using System;

namespace Otus.Teaching.PromoCodeFactory.WebHost
{
  public class AppOptions
  {
    public string ElasticApiKey { get; set; }

    public RedisOptions Redis { get; set; }
  }

  public class RedisOptions
  {
    public string Login { get; set; }
    public string Password { get; set; }
  }
}