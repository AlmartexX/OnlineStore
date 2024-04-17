using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.DTO;
using OnlineStore.BLL.Services;
using OnlineStore.BLL.Services.Interfaces;

namespace OnlineStore.UI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<CreateOrderDto>> CreateOrderAsync([FromBody] CreateOrderDto orderDTO, CancellationToken cancellationToken)
		{
			if (orderDTO == null)
			{
				return BadRequest("CreateOrderDto is null");
			}

			var createdOrder = await _orderService.CreateOrderAsync(orderDto, cancellationToken);

			return CreatedAtAction(nameof(CreateOrderAsync), createdOrder);
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrdersAsync([FromQuery] PaginationSettingsDTO paginationSettingsDTO, CancellationToken cancellationToken)
		{
			var orders = await _orderService.GetOrdersAsync(paginationSettingsDTO, cancellationToken);

			return Ok(orders);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByIdAsync(int id, [FromQuery] PaginationSettingsDTO paginationSettingsDTO, CancellationToken cancellationToken)
		{
			var orders = await _orderService.GetOrdersByIdAsync(id, paginationSettingsDTO, cancellationToken);

			return Ok(orders);
		}

		[HttpGet("{id}/OrderItems")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<OrderDto>> GetOrderByIdIncludeOrderItemAsync(int id, CancellationToken cancellationToken)
		{
			var order = await _orderService.GetOrderByIdIncludeOrderItemAsync(id, cancellationToken);

			return Ok(order);
		}
	}
}
