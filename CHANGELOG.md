# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

(None)

## [2.0.0] - 2019-10-22

### Added
- XML Documentation for every public API

### Fixed
- Missing `TryGetComponent` on Unity 2018.4 and Unity 2019.1

### Changed
- Renamed `IWorldCallbackReceiver.OnAddComponent` to `OnCreatedComponent` for clarity
- Renamed `IWorldCallbackReceiver.OnRemoveComponent` to `OnDestroyingComponent` for clarity
- Changed parameter type for `SystemComponents.Add` and `SystemComponents.Remove` from `Component` to `GameObject` 
- Made various utility classes internal
- Moved internal classes to a separate folder

## [1.0.0] - 2019-10-21

### Added
- Initial Public Release