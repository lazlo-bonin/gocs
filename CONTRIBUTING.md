# Forking & Contributing

If you want to fork or contribute to GoCS, you can use the following setup to create a development project for the package.

1. Clone the GoCS repo or its fork inside an empty directory, for example `gocs_package`
2. Create a new empty Unity project, for example `gocs_project`
3. Create symlinks to make Unity recompile modifications instantly:
    - from `gocs_package` to `gocs_project/Packages/gocs`
    - from `gocs_package/Samples~` to `gocs_project/Assets/Samples`

On Windows, you can use [Link Shell Extension](http://schinagl.priv.at/nt/hardlinkshellext/linkshellextension.html) to create a symlink. Make sure to drop the link as a **Junction**.

On Mac, you can use the terminal:

```batch
ln -s /path/to/gocs_package/ /path/to/gocs_project/Packages/gocs/
ln -s /path/to/gocs_package/Samples~/ /path/to/gocs_project/Assets/Samples/
```

### Coding Style

GoCS follows a coding style similar to Unity's:

- Public fields and properties: `camelCase`
- Private backing fields: `_camelCase`
- Public methods: `PascalCase`
- Constants: `PascalCase`
- Allman bracing style
- Tabs for indentation
- 1 blank line between each member
- 3 blank lines between each `#region`
- Implicit `var` typing when possible