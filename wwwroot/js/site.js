// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
  // Add event listeners for todo checkboxes
  const todoCheckboxes = document.querySelectorAll('.todo-checkbox');
  todoCheckboxes.forEach(checkbox => {
    checkbox.addEventListener('change', function () {
      const form = this.closest('form');
      if (form) {
        form.submit();
      }
    });
  });

  // Add event listener for the new todo form
  const newTodoForm = document.getElementById('newTodoForm');
  if (newTodoForm) {
    newTodoForm.addEventListener('submit', function (e) {
      const titleInput = document.getElementById('Title');
      if (titleInput && !titleInput.value.trim()) {
        e.preventDefault();
        alert('Please enter a title for your todo item.');
      }
    });
  }
});