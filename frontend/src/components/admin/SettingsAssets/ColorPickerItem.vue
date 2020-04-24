<template>
  <article class="color-picker">
    <label>{{text}}</label>
    <input type="color" :value="value" @input="$emit('input', $event.target.value)" />
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

.color-picker input {
  padding: 0;
  max-width: 200px;
}
</style>