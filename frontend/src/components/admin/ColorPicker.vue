<template>
  <article class="color-picker card">
    <h2 class="color-picker">
      <label class="label">
        {{text}}
        <input
          type="color"
          :id="text"
          :value="value"
          @input="$emit('input', $event.target.value)"
        />
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
  border-radius: 20px;
  display: flex;
  flex-direction: column;
}

input {
  height: 30px;
  width: 100%;
  border-radius: 20px;
  overflow: hidden;
  cursor: pointer;
}
</style>