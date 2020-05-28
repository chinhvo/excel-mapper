﻿using System.Reflection;
using ExcelMapper.Abstractions;

namespace ExcelMapper
{
    /// <summary>
    /// Reads a single cell of an excel sheet and maps the value of the cell to the
    /// type T.
    /// </summary>
    /// <typeparam name="T">The type of the member to map the value of a single cell to.</typeparam>
    public class OneToOnePropertyMap<T> : OneToOnePropertyMap, IValuePipeline<T>
    {
        /// <summary>
        /// Constructs a map that reads the value of a single cell and maps the value of the cell
        /// to the type of the property or field.
        /// </summary>
        /// <param name="member">The property or field to map the value of a single cell to.</param>
        /// <param name="pipeline">The pipeline to convert the string to an objet.</param>
        public OneToOnePropertyMap(MemberInfo member, ISingleCellValueReader reader) : base(member, reader)
        {
        }
    }
}