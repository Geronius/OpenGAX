﻿//===================================================================================
// Microsoft patterns & practices
// Guidance Automation Extensions
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// License: MS-LPL
//===================================================================================

#region Using directives

using System;
using System.ComponentModel;
using EnvDTE;
using Microsoft.Practices.ComponentModel;
using System.Globalization;

#endregion

namespace Microsoft.Practices.RecipeFramework.Library.Converters
{
    /// <summary>
    /// A converter that validates that the input value is a path to a project item, 
    /// with the same rules as the <see cref="DteElementConverter"/>, but ensuring 
    /// the target is always an item.
    /// </summary>
	public class ProjectItemOrEmptyConverter : ProjectItemConverter
    {
        /// <summary>
        /// Converts an element into its path location relative to the solution.
        /// </summary>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            // If the value is implementing all interfaces it means it is the empty value we defined
            if ((destinationType == typeof(string)) && (value is ProjectItem) && (value is Project) && (value is EnvDTE.Solution) && (value is EnvDTE80.SolutionFolder))
            {
				return string.Empty;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
