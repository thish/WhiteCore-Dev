/*
 * Copyright (c) Contributors, http://whitecore-sim.org/, http://aurora-sim.org
 * See CONTRIBUTORS.TXT for a full list of copyright holders.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the WhiteCore-Sim Project nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using WhiteCore.Framework.Utilities;

namespace WhiteCore.DataManager.Migration.Migrators.Auth
{
    public class AuthMigrator_0 : Migrator
    {
        public AuthMigrator_0()
        {
            Version = new Version(0, 0, 0);
            MigrationName = "Auth";

            schema = new List<SchemaDefinition>();

            //
            // Change summery:
            //
            //   Force the tables to lowercase
            //     Note: we do multiple renames here as it doesn't 
            //     always like just switching to lowercase (as in SQLite)
            //
            this.RenameSchema("Auth", "auth");
            this.RenameSchema("Tokens", "tokens");

            //Remove the old name
            this.RemoveSchema("auth");
            this.RemoveSchema("tokens");
            //Add the new lowercase one
            AddSchema("auth", ColDefs(
                ColDef("UUID", ColumnTypes.Char36),
                ColDef("passwordHash", ColumnTypes.Char32),
                ColDef("passwordSalt", ColumnTypes.Char32),
                ColDef("webLoginKey", ColumnTypes.String255),
                ColDef("accountType", ColumnTypes.Char32)
                                  ), IndexDefs(
                                      IndexDef(new string[1] {"UUID"}, IndexType.Primary)
                                         ));

            AddSchema("tokens", ColDefs(
                ColDef("UUID", ColumnTypes.Char36),
                ColDef("token", ColumnTypes.String255),
                ColDef("validity", ColumnTypes.Date)
                                    ), IndexDefs(
                                        IndexDef(new string[2] {"UUID", "token"}, IndexType.Primary)
                                           ));
        }

        protected override void DoCreateDefaults(IDataConnector genericData)
        {
            EnsureAllTablesInSchemaExist(genericData);
        }

        protected override bool DoValidate(IDataConnector genericData)
        {
            return TestThatAllTablesValidate(genericData);
        }

        protected override void DoMigrate(IDataConnector genericData)
        {
            DoCreateDefaults(genericData);
        }

        protected override void DoPrepareRestorePoint(IDataConnector genericData)
        {
            CopyAllTablesToTempVersions(genericData);
        }
    }
}