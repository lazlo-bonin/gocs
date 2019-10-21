using UnityEngine;
using UnityEngine.EventSystems;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class GuiProxy : BaseComponent,
		ISubmitHandler, ICancelHandler,
		ISelectHandler, IDeselectHandler,
		IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler,
		IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,
		IScrollHandler,
		IMoveHandler
	{
		public Event<BaseEventData> onSubmit { get; } = new Event<BaseEventData>();

		public Event<BaseEventData> onCancel { get; } = new Event<BaseEventData>();

		public Event<BaseEventData> onSelect { get; } = new Event<BaseEventData>();

		public Event<BaseEventData> onDeselect { get; } = new Event<BaseEventData>();

		public Event<PointerEventData> onBeginDrag { get; } = new Event<PointerEventData>();

		public Event<PointerEventData> onDrag { get; } = new Event<PointerEventData>();

		public Event<PointerEventData> onEndDrag { get; } = new Event<PointerEventData>();

		public Event<PointerEventData> onDrop { get; } = new Event<PointerEventData>();

		public Event<PointerEventData> onPointerEnter { get; } = new Event<PointerEventData>();

		public Event<PointerEventData> onPointerExit { get; } = new Event<PointerEventData>();

		public Event<PointerEventData> onPointerDown { get; } = new Event<PointerEventData>();

		public Event<PointerEventData> onPointerUp { get; } = new Event<PointerEventData>();

		public Event<PointerEventData> onPointerClick { get; } = new Event<PointerEventData>();

		public Event<PointerEventData> onScroll { get; } = new Event<PointerEventData>();

		public Event<AxisEventData> onMove { get; } = new Event<AxisEventData>();

		public void OnSubmit(BaseEventData eventData)
		{
			onSubmit.Invoke(eventData);
		}

		public void OnCancel(BaseEventData eventData)
		{
			onCancel.Invoke(eventData);
		}

		public void OnSelect(BaseEventData eventData)
		{
			onSelect.Invoke(eventData);
		}

		public void OnDeselect(BaseEventData eventData)
		{
			onDeselect.Invoke(eventData);
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			onBeginDrag.Invoke(eventData);
		}

		public void OnDrag(PointerEventData eventData)
		{
			onDrag.Invoke(eventData);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			onEndDrag.Invoke(eventData);
		}

		public void OnDrop(PointerEventData eventData)
		{
			onDrop.Invoke(eventData);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			onPointerEnter.Invoke(eventData);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			onPointerExit.Invoke(eventData);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			onPointerDown.Invoke(eventData);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			onPointerDown.Invoke(eventData);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			onPointerClick.Invoke(eventData);
		}

		public void OnScroll(PointerEventData eventData)
		{
			onScroll.Invoke(eventData);
		}

		public void OnMove(AxisEventData eventData)
		{
			onMove.Invoke(eventData);
		}
	}
}