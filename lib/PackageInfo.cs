public class PackageInfo
{
    public string PackageVersion { get; set; }
    public string Package32Url { get; set; }
    public string Package64Url { get; set; }

    #region BuildFolders

    public string BinDir { get => "bin"; }
    public string TempDir { get => "temp"; }

    #endregion

    #region PackageSettings

    public ChocolateyPackSettings PackageSettings
    {
        get => new ChocolateyPackSettings
        {
            //PACKAGE SPECIFIC SECTION
            Id = "fx-win",
            Version = "20.0.2",
            PackageSourceUrl = new Uri("https://github.com/user/choco-fx/"),
            Owners = new[] {
                "zverev-iv"
                },
            //SOFTWARE SPECIFIC SECTION
            Title = "fx",
            Authors = new[] {
                "Anton Medvedev (antonmedv)"
                },
            Copyright = "2021, antonmedv",
            ProjectUrl = new Uri("https://fx.wtf"),
            ProjectSourceUrl = new Uri("https://github.com/antonmedv/fx"),
            IconUrl = new Uri("https://medv.io/assets/fx-logo.png"),
            DocsUrl = new Uri("https://github.com/antonmedv/fx/blob/master/DOCS.md"),
            BugTrackerUrl = new Uri("https://github.com/antonmedv/fx/issues"),
            LicenseUrl = new Uri("https://github.com/antonmedv/fx/blob/master/LICENSE"),
            RequireLicenseAcceptance = false,
            Summary = "Command-line JSON processing tool",
            Description = @"## Features

* Easy to use
* Standalone binary
* Interactive mode 🎉
* Streaming support 🌊

## Usage

Start [interactive mode](https://github.com/antonmedv/fx/blob/master/DOCS.md#interactive-mode) without passing any arguments.
```bash
$ curl ... | fx
```

Or by passing filename as first argument.
```bash
$ fx data.json
```

Pass a few JSON files.
```bash
cat foo.json bar.json baz.json | fx .message
```

Use full power of JavaScript.
```bash
$ curl ... | fx '.filter(x => x.startsWith(""a""))'
```

Access all lodash (or ramda, etc) methods by using [.fxrc](https://github.com/antonmedv/fx/blob/master/DOCS.md#using-fxrc) file.
```bash
$ curl ... | fx '_.groupBy(""commit.committer.name"")' '_.mapValues(_.size)'
```

Update JSON using spread operator.
```bash
$ echo '{""count"": 0}' | fx '{...this, count: 1}'
{
  ""count"": 1
}
```

Extract values from maps.
```bash
$ fx commits.json | fx .[].author.name
```

Print formatted JSON to stdout.
```bash
$ curl ... | fx .
```

Pipe JSON logs stream into fx.
```bash
$ kubectl logs ... -f | fx .message
```

And try this:
```bash
$ fx --life
```

## Documentation

See full [documentation](https://github.com/antonmedv/fx/blob/master/DOCS.md).",
            ReleaseNotes = new[] {
                "https://github.com/antonmedv/fx/releases"
                },
            Files = new[] {
                new ChocolateyNuSpecContent {
                    Source = new DirectoryPath(BinDir).Combine("**").ToString(),
                    Target = "tools"
                    }
                },
            Tags = new[] {
                "fx",
                "js",
                "json",
                "cli",
                "terminal"
                },

            //Cake internal settings
            //Debug = false,
            //Verbose = false,
            //Force = false,
            //Noop = false,
            //LimitOutput = false,
            //ExecutionTimeout = 13,
            //CacheLocation = @"C:\temp",
            //AllowUnofficial = false

        };
    }

    #endregion
}
