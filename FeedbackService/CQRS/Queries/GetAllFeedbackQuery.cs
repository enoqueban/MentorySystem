// CQRS/Queries/GetAllFeedbackQuery.cs
using FastEndpoints;
using FeedbackService.Models;

namespace FeedbackService.CQRS.Queries;

public class GetAllFeedbackQuery : ICommand<List<Feedback>> { }
