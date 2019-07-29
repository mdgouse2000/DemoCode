﻿// Copyright 2019 Jon Skeet. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

namespace VDrumExplorer.Data.Fields
{
    public class FieldCondition
    {
        public ModuleAddress ReferenceAddress { get; }
        public int RequiredValue { get; }

        public FieldCondition(ModuleAddress referenceAddress, int requiredValue) =>
            (ReferenceAddress, RequiredValue) = (referenceAddress, requiredValue);

        public bool IsEnabled(ModuleData data, IField field)
        {
            var container = data.Schema.ParentsByField[field];
            var referenceField = (NumericFieldBase)container.FieldsByAddress[ReferenceAddress];
            int value = referenceField.GetRawValue(data);
            return value == RequiredValue;
        }
    }
}
