<template>
  <article class="dish-types card">
    <h2 class="dish-types-header">
      <label class="label">
        {{text}}
        <input
          type="text"
          placeholder="Ny kategori"
          @input="$emit('input', $event.target.value)"
        />
      </label>
    </h2>
  </article>
</template>

<script>
export default {
  name: "DishTypeAdder",
  props: {
    text: String
  }
};
</script>

<style scoped>
.dish-types {
  border-radius: 20px;
  display: flex;
  flex-direction: column;
}

input {
  height: 30px;
  width: 100%;
  border-radius: 5px;
  border: 1px solid black;
}
</style>