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
});
</script>

<template>
    <div class="w-full flex flex-col float-left gap-2">
        <label :for="label" class="text-white font-semibold text-xl pl-1">{{ label }}</label>
        <textarea :value="modelValue" @input="$emit('update:modelValue', $event.target?.value)" :name="label"
            class="w-full rounded-md p-5 min-h-[250px]" placeholder="This is a great section body" />
    </div>
</template>