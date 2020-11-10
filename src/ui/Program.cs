// Copyright (c) 2020 Yoann MOUGNIBAS
//
// This file is part of MusicWorkflow.
//
// MusicWorkflow is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MusicWorkflow is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MusicWorkflow.  If not, see <https://www.gnu.org/licenses/>.

namespace Mougnibas.MusicWorkflow.UI
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Mougnibas.MusicWorkflow.Contract.Service;
    using Mougnibas.MusicWorkflow.Provider.Fake;

    /// <summary>
    /// Blazor web assembly entry point class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Blazor web assembly entry point method.
        /// </summary>
        /// <param name="args">Not used.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            // Create a default builder
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            // Add a service
            // TODO Use a setting to register the appropriate implementation given the context
            builder.Services.AddSingleton<IMusicService, FakeMusicService>();

            // Use this root component
            builder.RootComponents.Add<App>("#app");

            // Build it
            var host = builder.Build();

            // Initialize the service
            var musicService = host.Services.GetRequiredService<IMusicService>();
            musicService.Init();

            // Run it (async)
            await host.RunAsync().ConfigureAwait(true);
        }
    }
}
