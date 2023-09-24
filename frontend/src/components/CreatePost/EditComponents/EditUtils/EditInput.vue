<script setup>
const { modelValue, label } = defineProps({
    modelValue: {
        type: String,
        required: true
    },
    label: {
        type: String,
        required: true
    }
})
</script>

<template>
    <div class="flex flex-col gap-1">
        <label class="text-white font-semibold text-xl" :for="label">{{ label }}</label>
        <input :value="modelValue" @input="$emit('update:modelValue', $event.target?.value)" :name="label"
            class="w-80 px-2 py-3 rounded-md" placeholder="Great Section Below" />
    </div>
</template>
