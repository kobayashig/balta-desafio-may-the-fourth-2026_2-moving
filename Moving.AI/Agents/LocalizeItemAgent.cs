using System.Text.Json;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moving.AI.Models;
using Moving.AI.Providers.Abstraction;
using Moving.Core;
using Moving.Core.Agents.Abstractions;
using Moving.Core.Enums;
using Moving.Core.Models;
using OpenAI.Chat;

namespace Moving.AI.Agents;

public class LocalizeItemAgent(
    ILogger<LocalizeItemAgent> logger,
    
    [FromKeyedServices(PromptProvider.File)]
    IPromptProvider promptProvider) : IAgent<Item, string>
{
    private const string AgentName = "LocalizeItemAgent";
    private const string Prompt = "Localize a caixa em que está o item: ";
    private const float Temperature = 0.7f;
    
    public async Task<string> RunAsync(Item item, CancellationToken cancellationToken)
    {
        logger.LogInformation("Localizando a caixa em que o item se encontra.");

        var client = new OpenAI.OpenAIClient(Configuration.OpenAi.ApiKey);
        var instructions = await promptProvider.GetPromptAsync(AgentName, cancellationToken);

        var agent = client
                    .GetChatClient(AiModels.Gpt4OMini)
                    .AsAIAgent(new ChatClientAgentOptions
                    {
                        Name = AgentName,
                        Description = "Agente especialista em localizar itens.",
                        ChatOptions = new ChatOptions
                        {
                            ModelId = AiModels.Gpt4OMini,
                            Temperature = Temperature,
                            Instructions = instructions
                        }
                    });

        var prompt = $"{Prompt} {JsonSerializer.Serialize(item)}";
        var response = await agent.RunAsync<string>(prompt, cancellationToken: cancellationToken);
        
        logger.LogInformation("Item localizado.");
        logger.LogInformation(response.Result);
        
        return response.Result;
    }
}