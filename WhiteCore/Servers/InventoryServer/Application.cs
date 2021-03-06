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

using WhiteCore.Framework;
using WhiteCore.Framework.Modules;
using WhiteCore.Framework.Services;
using WhiteCore.Simulation.Base;
using System;
using System.Collections.Generic;

namespace WhiteCore.Servers.InventoryServer
{
    /// <summary>
    ///     Starting class for the WhiteCore Server
    /// </summary>
    public class Application
    {
        public static void Main(string[] args)
        {
            BaseApplication.BaseMain(args, "WhiteCore.InventoryServer.ini",
                                     new MinimalSimulationBase("WhiteCore.InventoryServer ",
                                                               new List<Type>
                                                                   {
                                                                       typeof (IInventoryData),
                                                                       typeof (IUserAccountData),
                                                                       typeof (IAssetDataPlugin),
                                                                       typeof (ISimpleCurrencyConnector),
                                                                       typeof (IAgentInfoConnector)
                                                                   },
                                                               new List<Type>
                                                                   {
                                                                       typeof (IInventoryService),
                                                                       typeof (ILibraryService),
                                                                       typeof (IUserAccountService),
                                                                       typeof (IAssetService),
                                                                       typeof (IMoneyModule),
                                                                       typeof (ISyncMessagePosterService),
                                                                       typeof (ISyncMessageRecievedService),
                                                                       typeof (IAgentInfoService),
                                                                       typeof (IExternalCapsHandler),
                                                                       typeof (IConfigurationService),
                                                                       typeof (IGridServerInfoService),
                                                                       typeof (IJ2KDecoder)
                                                                   }));
        }
    }
}