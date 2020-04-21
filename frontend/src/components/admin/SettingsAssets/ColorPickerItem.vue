<template>
  <article class="color-picker">
    <h2 class="color-picker">
      <label class="label">
        {{text}}
        <input type="color" :value="value" @input="$emit('input', $event.target.value)" />
      </label>
    </h2>
  </article>
</template>

<script>
export default {
  name: "ColorPicker",
  props: {
    text: String,
    value: String
  }
};
</script>

<style scoped>
.color-picker {
  display: flex;
  flex-direction: column;
}

input {
  height: 30px;
  width: 100%;
  overflow: hidden;
  cursor: pointer;
  border: none;
  background: transparent;
}

input::-webkit-color-swatch {
  border: none;
}
</style>