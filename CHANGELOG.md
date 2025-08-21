# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.1.0] / 2025-08-21
### Features
- Support Revit 2025+
### Updates
- Update `ElementIdConverter` to support Revit 2024+
### Fixes
- Fix `ObjectJsonConverter` to support `null` value.
- Fix `XYZConverter` to support `null` value.

## [1.0.3] / 2022-10-10
### Features
- Add `ObjectJsonConverter` abstraction

## [1.0.2] / 2022-10-03
- Update `Newtonsoft.Json` to `Version="9.*"`

## [1.0.1] / 2022-08-30 - 2022-03-21
- Add XYZConverter 
- Add IJsonService<TJson> / IJsonService

## [1.0.0] / 2022-02-26
- Push to Nuget
- Add JsonService & ElementIdConverter
- Add Build Project
- First Release

[vNext]: ../../compare/1.0.0...HEAD
[1.1.0]: ../../compare/1.0.0...1.1.0
[1.0.3]: ../../compare/1.0.2...1.0.3
[1.0.2]: ../../compare/1.0.1...1.0.2
[1.0.1]: ../../compare/1.0.0...1.0.1
[1.0.0]: ../../compare/1.0.0