# Forking & Contributing

If you want to fork or contribute to GOCS, you can use the following setup to create a development project for the package.

1. Clone the GOCS repo or its fork inside an empty directory, for example `gocs_package`
2. Create a new empty Unity project, for example `gocs_project`
3. Symlink `gocs_package` to `gocs_project/Packages/gocs`:
    - On Windows, you can use [Link Shell Extension](http://schinagl.priv.at/nt/hardlinkshellext/linkshellextension.html) to create a **junction**
    - On Mac, you can use the terminal (untested):
    `ln -s /path/to/gocs_package/ /path/to/gocs_project/Packages/gocs`
4. Changes you make to GOCS will be instantly compiled by Unity

### Coding Style

GOCS follows a coding style similar to Unity's:

- Public fields and properties: `camelCase`
- Private backing fields: `_camelCase`
- Public methods: `PascalCase`
- Constants: `PascalCase`
- Allman bracing style
- Tabs for indentation
- 1 blank line between each member
- 3 blank lines between each `#region`
- Implicit `var` typing when possible

---

GOCS is in early preview stages and is not yet considered to be production ready, so we reserve the right to make breaking API changes until then. I'm open to suggestions and appreciate bug reports. If you have any, just create a new issue on Github!